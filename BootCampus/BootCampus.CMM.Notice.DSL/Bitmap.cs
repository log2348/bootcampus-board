using System.IO;

namespace BootCampus.CMM.Notice.DSL
{
    internal class Bitmap
    {
        private MemoryStream memoryStream;

        public Bitmap(MemoryStream memoryStream)
        {
            this.memoryStream = memoryStream;
        }
    }
}