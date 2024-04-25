using Microsoft.EntityFrameworkCore;
using Quizzely.Core.Models;
using Quizzely.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quizzely.Repository.Data.DataSeeding
{
    public static class DataContextSeed
    {
        public static async Task DataSeed(SqlDataContext context)
        {
            if (!context.Set<McqQuestion>().Any())
            {

                var mcqsData = await File.ReadAllTextAsync("../Quizzely.Repository/Data/DataSeeding/SQL/mcq-sql.json");

                var mcqs = JsonSerializer.Deserialize<List<McqQuestion>>(mcqsData);

                if (mcqs != null && mcqs.Any())
                {
                    await context.Set<McqQuestion>().AddRangeAsync(mcqs);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<TofQuestion>().Any())
            {

                var tofsData = await File.ReadAllTextAsync("../Quizzely.Repository/Data/DataSeeding/SQL/tof-sql.json");

                var tofs = JsonSerializer.Deserialize<List<TofQuestion>>(tofsData);

                if (tofs != null && tofs.Any())
                {
                    await context.Set<TofQuestion>().AddRangeAsync(tofs);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
