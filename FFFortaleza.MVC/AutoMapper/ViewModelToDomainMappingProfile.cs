using AutoMapper;
using CrdFortes.Domain.Entities;
using CrdFortes.MVC.ViewModels;

namespace CrdFortes.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Operacao, OperacaoViewModel>();
        }
    }
}