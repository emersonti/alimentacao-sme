using AutoMapper;
using codae.backend.application.ViewModels;
using codae.backend.core.Models;
using codae.backend.data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace codae.backend.application.Services
{
    public class RegiaoService: IRegiaoService
    {
        private readonly IMapper _mapper;
        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoService(IRegiaoRepository regiaoRepository, IMapper mapper)
        {
            _regiaoRepository = regiaoRepository;
            _mapper = mapper;
        }

        public int CreateRegiao(RegiaoViewModel regiao)
        {
            var newRegiao = _mapper.Map<Regiao>(regiao);
            _regiaoRepository.Add(newRegiao);
            _regiaoRepository.SaveChanges();

            return newRegiao.RegiaoId;
        }

        public void UpdateRegiao(RegiaoViewModel regiao)
        {
            var existing = _mapper.Map<Regiao>(regiao);

            _regiaoRepository.Update(existing);
            _regiaoRepository.SaveChanges();            
        }

        public void RemoveRegiao(int regiaoId)
        {
            _regiaoRepository.Remove(_regiaoRepository.GetByKey(regiaoId));
            _regiaoRepository.SaveChanges();
        }

        public IEnumerable<RegiaoViewModel> GetAll() => 
            _mapper.Map<IEnumerable<RegiaoViewModel>>(_regiaoRepository.GetAll());

        public RegiaoViewModel GetByKey(int regiaoId) =>
            _mapper.Map<RegiaoViewModel>(_regiaoRepository.GetByKey(regiaoId));
    }
}