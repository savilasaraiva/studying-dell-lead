using _03_EFCore.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_EFCore.WebAPI.Repository
{
    public class HeroisRepository
    {
        private readonly HeroiContext _context;

        public HeroisRepository(HeroiContext context)
        {
            _context = context;
        }

        /*public async System.Threading.Tasks.Task<object> GetHeroisAsync()
        {
            HeroiContext heroiContext = new HeroiContext();

        }*/
    }
}
