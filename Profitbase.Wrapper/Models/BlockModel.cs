using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper.Enums;

namespace Profitbase.Wrapper.Models
{
    public class BlockModel
    {
        /// <summary>
        /// Статус помещения
        /// </summary>
        public BlockStatus Status { get; set; }

        /// <summary>
        /// Идентификатор помещения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Секция
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Название дома
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Название жилого комплекса
        /// </summary>
        public string ResComplexName { get; set; }

        /// <summary>
        /// Количество комнат
        /// </summary>
        public int RoomsCount { get; set; }

        /// <summary>
        /// Код планировки
        /// </summary>
        public string LayoutCode { get; set; }

        /// <summary>
        /// Планировка
        /// </summary>
        public string LayoutRef { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Цена квартиры
        /// </summary>
        public int PriceTotal { get; set; }

        /// <summary>
        /// Является студией
        /// </summary>
        public string Type { get; set; }
    }
}
