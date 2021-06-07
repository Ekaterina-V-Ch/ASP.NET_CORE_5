using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data.Models
{
    public class VideoCard
    {
        public int ID { set; get; }
        //Название видеокарты
        public string VideoCardName { set; get; }
        //Графический процессор
        public string GraphicsProcessor { set; get; }
        //Тип памяти
        public string MemoryType { set; get; }
        //Объем видеопамяти
        public string VideoMemoryCapacity { set; get; }
        //Производитель графического процессора
        public string GPUManufacturer { set; get; }

    }
}
