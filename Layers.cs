using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ColorLogoMaker
{
    class Layers
    {
        LayeredImage m_oImage;
        ArrayList m_arLayers = new ArrayList();

        public Layers(LayeredImage image)
        {
            m_oImage = image;
        }

        public Int32 Count
        {
            get { return m_arLayers.Count; }
        }

        public Layer Add()
        {
            Layer layer = new Layer(m_oImage.Width, m_oImage.Height);
            m_arLayers.Add(layer);
            return layer;
        }

        public Layer Copy(Layer layer)
        {
            Layer layerCopy = (Layer)layer.Clone();
            m_arLayers.Add(layerCopy);
            return layerCopy;
        }

        public Layer this[Int32 i]
        {
            get { return (Layer)m_arLayers[i]; }
        }
    }
}
