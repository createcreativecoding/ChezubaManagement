using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChezubaManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(

               new Project
               {
                   Id = 1,
                   NGO_name = "Waasta",
                   Heading = "Advocate",
                   Site = "Onsite",
                   Duration = 2,
                   Time_com = 2,
                   Address = " Kharag Singh Road",
                   Name = " Rajesh Verma",
                   Phone = 123456789
               },

               new Project
               {  
                   Id = 2, 
                   NGO_name="Niswarth", 
                   Heading="Graphic Designer", 
                   Site="Online", Duration= 1 , 
                   Time_com= 12 ,
                   Address=" Uttoroyan,F-Block",
                   Name=" Sameer Lama",
                   Phone=456789123
               },

               new Project
               {
                 Id = 3,
                   NGO_name="Disha",
                   Heading="Translator", 
                   Site="Online", 
                   Duration= 3 , 
                   Time_com= 2 ,
                   Address="Hakimpra",
                   Name=" Tushar Singh",
                   Phone=789123456

               }


               );
        }


       
    }
}
