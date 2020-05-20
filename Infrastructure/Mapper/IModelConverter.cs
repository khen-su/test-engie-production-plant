using System;
namespace Infrastructure.Mapper
{
    public interface IModelConverter<TModel, TViewModel>
    {
        TModel ToModel(TViewModel persisted);
        TViewModel ToViewModel(TModel model);
    }
}
