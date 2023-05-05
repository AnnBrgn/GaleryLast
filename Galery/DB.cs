using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galery
{
    public class DB
    {
        private static GalleryContext instance;

        public static GalleryContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new GalleryContext();
                return instance;
            }
        }
    }
}
