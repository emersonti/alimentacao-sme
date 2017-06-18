namespace codae.backend.interfaces
{
    /// <summary>
    /// Interface que define uma Unidade de Trabalho (UnitofWork ou UOW)
    /// </summary>
    public interface IUnitofWork
    {
        /// <summary>
        /// Realiza o Commit da transação atual
        /// </summary>
        /// <returns>Verdadeiro se pelo menos 1 linha foi afetada</returns>
        bool Commit();
    }
}
