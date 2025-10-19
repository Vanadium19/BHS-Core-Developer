namespace BHS.Core;

public interface IEcsService
{
    void Initialize();
    void Run();
    void Dispose();
}