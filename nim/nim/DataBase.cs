using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nim
{
    class DataBase
    {
        //параметры по у молчанию для кнопки "Начать заново"
        public static bool FirstStepDefault = true; //true - игрок, false - компьютер (правого первого хода)
        public static int[] HeapsDefault = { 3, 5, 7 };  //информация о каждой куче
        
        public static bool FirstStep = FirstStepDefault;
        public static int[] Heaps = HeapsDefault;
    }
}
