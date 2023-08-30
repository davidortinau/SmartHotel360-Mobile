using Microcharts;
using SkiaSharp;
using System;
using System.Linq;

namespace SmartHotel.Clients.Core.Controls
{
    public class TemperatureChart : Chart
    {
        public TemperatureChart()
        {
            BackgroundColor = SKColor.Parse("#F2F2F2");

            LabelTextSize = 24f;
        }

        public IEnumerable<ChartEntry> Entries
        {
            get { return entries; }
            set { entries = value; }
        }

        public float CaptionMargin { get; set; } = 12;

        public float LineSize { get; set; } = 28;

        public float StartAngle { get; set; } = -180;

		public ChartEntry CurrentValueEntry { get; set; }

		public ChartEntry DesiredValueEntry { get; set; }

		protected float AbsoluteMinimum => entries.Select(x => x.Value ?? 0).Concat(new[] { MaxValue, MinValue, InternalMinValue ?? 0 }).Min(x => Math.Abs(x));

        float AbsoluteMaximum => entries.Select(x => x.Value ?? 0).Concat(new[] { MaxValue, MinValue, InternalMinValue ?? 0 }).Max(x => Math.Abs(x));

        protected float ValueRange => AbsoluteMaximum - AbsoluteMinimum;

        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            var relativeScaleWidth = width / 465.0f;
            var strokeWidth = relativeScaleWidth * LineSize;

            var radius = (width) * 2.0f / 4f;
            var cx = (int)(radius);
            var cy = Convert.ToInt32((height / 2.0f) + radius / 3.7f); 
            var radiusSpace = radius - 4 * strokeWidth; 

            DrawChart(canvas, width, height, cx, cy, radiusSpace, strokeWidth, relativeScaleWidth);
        }

        protected void DrawChart(SKCanvas canvas, int width, int height, int cx, int cy, float radiusSpace, float strokeWidth, float relativeScaleWidth)
        {

            foreach (var entry in entries)
            {
                DrawChart(canvas, entry, radiusSpace, cx, cy, strokeWidth);
            }

            DrawCaption(canvas, cx, cy, radiusSpace, relativeScaleWidth, strokeWidth);
        }

        protected virtual void DrawChart(SKCanvas canvas, ChartEntry entry, float radius, int cx, int cy, float strokeWidth)
        {
            using (var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = strokeWidth,
                StrokeCap = SKStrokeCap.Round,
                Color = entry.Color,
                IsAntialias = true
            })
            {
                using (var path = new SKPath())
                {
                    var sweepAngle = 180 * (Math.Abs(entry.Value ?? 0) - AbsoluteMinimum) / ValueRange;
                    path.AddArc(SKRect.Create(cx - radius, cy - radius, 2 * radius, 2 * radius), StartAngle, sweepAngle);

                    canvas.DrawPath(path, paint); 
                }
            }
        }

        protected virtual void DrawCaption(SKCanvas canvas, int cx, int cy, float radius, float relativeScaleWidth,
            float strokeWidth)
        {
            var medium = AbsoluteMinimum + ((AbsoluteMaximum - AbsoluteMinimum) / 2);

            SKPaint paint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = LabelTextSize * relativeScaleWidth,
                TextAlign = SKTextAlign.Center
            };

            canvas.DrawText($"{AbsoluteMinimum}°", new SKPoint(cx - radius - strokeWidth - CaptionMargin, cy), paint);
            canvas.DrawText($"{medium}°", new SKPoint(cx, cy - radius - strokeWidth - 2 * relativeScaleWidth), paint);
            canvas.DrawText($"{AbsoluteMaximum}°", new SKPoint(cx + radius + strokeWidth + CaptionMargin, cy), paint);

            var degreeSign = '°';
	        if (CurrentValueEntry != null)
            {
                SKPaint paint2 = new SKPaint
                {
                    Color = SKColor.Parse("#174A51"),
                    TextSize = LabelTextSize * relativeScaleWidth,
                    TextAlign = SKTextAlign.Center
                };

                canvas.DrawText(
                    $"Current: {CurrentValueEntry.Value}{degreeSign}",
                    new SKPoint(cx, cy - radius * 1.8f / 4f), 
                    paint2);
            }

	        if (DesiredValueEntry != null)
            {
                SKPaint paint3 = new SKPaint
                {
                    Color = SKColor.Parse("#378D93"),
                    TextSize = LabelTextSize * relativeScaleWidth,
                    TextAlign = SKTextAlign.Center
                };

                canvas.DrawText(
                    $"Desired: {DesiredValueEntry?.Value}{degreeSign}",
                    new SKPoint(cx, cy - radius * 0.9f / 4f),
                    paint3);   
	        }
        }
        
    }
}