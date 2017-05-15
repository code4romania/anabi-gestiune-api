using Anabi.DataAccess.Abstractions.Repositories;
using Anabi.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anabi.DataAccess.Repositories
{
    public class CategoriiRepository : ICategoriiRepository
    {
        

        public CategoriiRepository()
        {

        }

        public async Task<IEnumerable<Categorie>> GetCategoriiAsync()
        {
            return await getCategoriesAsync();
        }

        public async Task<IEnumerable<Categorie>> GetCategoriiFiltrateAsync(string filtru)
        {
            var lst = await getCategoriesAsync();

            lst = lst.Where(x => x.PentruEntitate == filtru);

            return lst;
        }

        private async Task<IEnumerable<Categorie>> getCategoriesAsync()
        {
            var lst = new List<Categorie>()
            {
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 1, Cod= "Bunuri Mobile", Descriere = "Bunuri mobile", ParinteId = null
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 2, Cod= "Bunuri Imobile", Descriere = "Bunuri imobile", ParinteId = null
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 3, Cod= "Bani", Descriere = "Bani", ParinteId = null
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 4, Cod= "Vehicul", Descriere = "Vehicul", ParinteId = 1
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 5, Cod= "Arma", Descriere = "Arma", ParinteId = 1
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 6, Cod= "Telefon mobil", Descriere = "Telefon mobil", ParinteId = 1
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 7, Cod= "Tigari", Descriere = "Tiari", ParinteId = 1
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 8, Cod= "Teren", Descriere = "Teren", ParinteId = 2
                },
                new Categorie(){
                    PentruEntitate = "bunuri", Id = 9, Cod= "Cladire", Descriere = "Cladire", ParinteId = 2
                }
                ,
                new Categorie(){
                    PentruEntitate = "decizie", Id = 10, Cod= "Hotarare", Descriere = "Hotarare", ParinteId = null
                }
                ,
                new Categorie(){
                    PentruEntitate = "decizie", Id = 11, Cod= "Ordonanta", Descriere = "Ordonanta", ParinteId = null
                }
            };
            return await Task.FromResult(lst);
        }


    }
}
