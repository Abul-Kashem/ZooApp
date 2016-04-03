using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewFood
    {
        public ViewFood(Food food)
        {
            Name = food.Name;
            Id = food.Id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
