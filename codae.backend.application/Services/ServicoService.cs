using System;
using codae.backend.application.ViewModels;
using AutoMapper;
using codae.backend.data.Repositories;
using System.Collections.Generic;
using codae.backend.core.Models;

namespace codae.backend.application.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;

        public ServicoService(IServicoRepository servicoRepository, 
            IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }

        public void CreateItemServico(int servicoId, int planoId, string nome)
        {
            var servico = _servicoRepository.GetByKey(servicoId);

            servico.AdicionarComponente(planoId, nome);

        }

        public int CreateServico(ServicoViewModel servico)
        {
            var newServico = _mapper.Map<Servico>(servico);

            _servicoRepository.Add(newServico);
            _servicoRepository.SaveChanges();

            return newServico.ServicoId;
        }

        public IEnumerable<ServicoViewModel> GetAll() =>
            _mapper.Map<IEnumerable<ServicoViewModel>>(_servicoRepository.GetAll());

       public ServicoViewModel GetByKey(int servicoId) =>
            _mapper.Map<ServicoViewModel>(_servicoRepository.GetByKey(servicoId));

        public void RemoveServico(int servicoId) =>
            _servicoRepository.Remove(servicoId);

        public void UpdateServico(ServicoViewModel servico)
        {
            var existing = _mapper.Map<Servico>(servico);

            _servicoRepository.Update(existing);
            _servicoRepository.SaveChanges();
        }
    }
}
