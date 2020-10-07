using BGB.Core.Validations;

namespace BGB.InternetBanking.Entities
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}