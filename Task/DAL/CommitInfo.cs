using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL
{
    public class CommitInfo
    {
        public String WhoCommit { get; set; }


        public DateTime DateCommit { get; set; }
        public int Quantity { get; set; }

        public double? AverageQuantity { get; set; }

        public String Description
        {
            get
            {
                String text = $"Autor: {WhoCommit} Data: {DateCommit.Date: dd:MM:yyyy} Ilość commitów: {Quantity}"; 
                
                if(AverageQuantity.HasValue)
                    text += $" Średnia ilość commitów: {Math.Round(AverageQuantity ?? 0, 2)}";

                return text;
            }
        }

        
    }
}
