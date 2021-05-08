using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork
{
    class NewImage
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public NewImage(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}
