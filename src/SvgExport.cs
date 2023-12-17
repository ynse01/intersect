using System.Text;
using System.Xml;

namespace Intersect {

    public class SvgExport
    {
        private XmlElement svgElement;

        public SvgExport(int width, int height) {
            var doc = new XmlDocument();
            var decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(decl);
            svgElement = doc.CreateElement("svg", "http://www.w3.org/2000/svg");
            svgElement.SetAttribute("viewBox", $"0 0 {width} {height}");
            if (!ReferenceEquals(doc, svgElement.OwnerDocument)) {
                throw new System.Exception();
            }
            doc.AppendChild(svgElement);
        }

        public void Draw(Ellipse2 ellipse, string fillColor) {
            ellipse.ToSvg(svgElement, fillColor);
        }

        public void Draw(PolyLine2 polyLine, string strokeColor) {
            polyLine.ToSvg(svgElement, strokeColor);
        }

        public void WriteToFile(string filePath) {
            XmlWriterSettings settings = new XmlWriterSettings {
                Indent = true,
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8
            };
            using (var writer = XmlWriter.Create(filePath, settings)) {
                svgElement.OwnerDocument.Save(writer);
                writer.Flush();
            }
        }
    }
}