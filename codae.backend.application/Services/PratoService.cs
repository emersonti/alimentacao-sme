using System;
using System.Collections.Generic;
using codae.backend.application.ViewModels;
using codae.backend.data.Repositories;
using AutoMapper;
using codae.backend.core.Models;
using System.Threading.Tasks;

namespace codae.backend.application.Services
{
    public class PratoService : IPratoService
    {
        private readonly IPratoRepository _pratoRepository;
        private readonly IMapper _mapper;

        public PratoService(IPratoRepository pratoRepository, IMapper mapper)
        {
            _pratoRepository = pratoRepository;
            _mapper = mapper;
        }

        public int CreateGrupoPrato(GrupoPratoViewModel grupoPratoVM)
        {
            var newGrupoPrato = _mapper.Map<Prato>(grupoPratoVM);

            _pratoRepository.Add(newGrupoPrato);
            _pratoRepository.SaveChanges();

            return newGrupoPrato.PratoId;
        }

        public int CreatePrato(PratoViewModel pratoVM)
        {
            var newPrato = _mapper.Map<Prato>(pratoVM);

            _pratoRepository.Add(newPrato);
            _pratoRepository.SaveChanges();

            return newPrato.PratoId;
        }

        public async Task<IEnumerable<GrupoPratoViewModel>> GetAllAsync() => _mapper.Map < IEnumerable < GrupoPratoViewModel>>(_pratoRepository.Find(p => p.GrupoPratoId == null));

        public GrupoPratoViewModel GetByKey(int grupoPratoId) => _mapper.Map<GrupoPratoViewModel>(_pratoRepository.GetByKey(grupoPratoId));

        public PratoViewModel GetPratoByKey(int pratoId) => _mapper.Map<PratoViewModel>(_pratoRepository.GetByKey(pratoId));

        public void RemoveGrupoPrato(int grupoPratoId)
        {
            _pratoRepository.Remove(_pratoRepository.GetByKey(grupoPratoId));
        }

        public void RemovePrato(int pratoId)
        {
            _pratoRepository.Remove(_pratoRepository.GetByKey(pratoId));
        }

        public void UpdateGrupoPrato(GrupoPratoViewModel grupoPratoVM)
        {
            var grupoPrato = _mapper.Map<Prato>(grupoPratoVM);

            _pratoRepository.Update(grupoPrato);
            _pratoRepository.SaveChanges();
        }

        public void UpdatePrato(PratoViewModel pratoVM)
        {
            var prato = _mapper.Map<Prato>(pratoVM);

            _pratoRepository.Update(prato);
            _pratoRepository.SaveChanges();
        }
    }
}
