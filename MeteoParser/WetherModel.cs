using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoParser
{
    class WetherModel
    {
        int t, p, W, d;
        public string DATE { get { return $"{d.ToString()} число";} set { int.TryParse(value, out d); } }
        public string TEMPERATURE { get { return $"{t.ToString()} градусов"; } set { int.TryParse(value, out t); } }// макс и мин
        public string PRESSURE { get { return $"{p.ToString()} мм. рт. ст."; } set { int.TryParse(value, out p); } }
        public string WIND { get { return $"{W.ToString()} м/с "; } set { int.TryParse(value, out W); } }

        //public override string ToString()
        //{
        //    return $"{TEMPERATURE} градусов {PRESSURE} мм. рт. ст. {WIND} м.с. ";
        //}
    }
}
