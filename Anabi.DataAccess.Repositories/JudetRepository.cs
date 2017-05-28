using Anabi.DataAccess.Abstractions.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Anabi.Domain.Core.Models;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;

namespace Anabi.DataAccess.Repositories
{
    public class JudetRepository : BaseRepository, IJudetRepository 
    {
        
        public JudetRepository(AnabiContext ctx)
        {
            context = ctx;
        }
        public async Task<IEnumerable<Judet>> GetJudeteAsync()
        {
           
                var result = await (from j in context.Judete
                                    select new Judet()
                                    {
                                        Id = j.Id,
                                        Abreviere = j.Abreviere,
                                        Denumire = j.Denumire
                                    }).ToListAsync();
                return result;
            
        }

        public async Task<IEnumerable<Judet>> GetJudeteFiltrateAsync(string filtru)
        {
            
                var result = await(from j in context.Judete
                                   where j.Abreviere == filtru
                                   select new Judet()
                                   {
                                       Id = j.Id,
                                       Abreviere = j.Abreviere,
                                       Denumire = j.Denumire
                                   }).ToListAsync();
                return result;
            
        }
    }
}
