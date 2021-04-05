using ModuleMatrixClustering.Model;
using Svg;
using Svg.Transforms;
using System;
using System.Drawing;

namespace ModuleMatrixClustering.Utils.Svg
{
    public class List2DExporter
    {
        public SvgDocument SvgDocument { get; set; }

        public List2DExporter()
        {
            SvgDocument = new SvgDocument();
            SvgDocument.Ppi = 300;
            SvgDocument.Width = 600;
            SvgDocument.Height = 600;
        }

        public RectangleF Draw(List2D<Item2D> list)
        {
            SvgPaintServer black = new SvgColourServer(Color.Black);
            SvgGroup pointGroup = new SvgGroup();

            foreach (Item2D item in list)
            {
                SvgCircle circle = new SvgCircle()
                {
                    CenterX = (int)Math.Floor(item.X * 100 + 0.5),
                    CenterY = (int)Math.Floor(item.Y * 100 + 0.5),
                    Fill = SvgPaintServer.None,
                    Stroke = black,
                    Radius = 4,
                };
                pointGroup.Children.Add(circle);
            }

            var pointBounds = pointGroup.Bounds;
            pointGroup.Transforms = new SvgTransformCollection();
            pointGroup.Transforms.Add(new SvgTranslate(-pointBounds.X, -pointBounds.Y));

            SvgDocument.Children.Add(pointGroup);
            return SvgDocument.Bounds;
        }

        public void SaveTo(string filename)
        {
            SvgDocument.Write(filename);
        }
    }
}
