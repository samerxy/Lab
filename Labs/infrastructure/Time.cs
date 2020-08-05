using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class Time
    {
        public int TimeID { get; set; }
        public string time { get; set; }
        public int DateID { get; set; }
        public Dates  dates { get; set; }
        public bool isAvailable { get; set; }
       
    }
    public class TimeConfigurations : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(c => c.TimeID);
            builder.Property(c => c.TimeID).ValueGeneratedOnAdd();
            builder.Property(c => c.time).IsRequired();
            builder.Property(c => c.DateID).IsRequired();
            builder.Property(c => c.isAvailable).IsRequired().HasDefaultValue(false);



            builder.HasData(new Time { TimeID = 1, time = "10:00am", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 2, time = "11:00am", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 3, time = "12:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 4, time = "01:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 5, time = "02:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 6, time = "03:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 7, time = "04:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 8, time = "05:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 9, time = "06:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 10,time = "07:00pm", isAvailable = false, DateID = 1 });
            builder.HasData(new Time { TimeID = 11, time ="08:00pm", isAvailable = false , DateID = 1 }); 
            builder.HasData(new Time { TimeID = 12, time = "09:00pm", isAvailable = false, DateID = 1 });

           

        }
    }
}
