namespace BHS.View;

public interface ISceneService
{
    void Add(SceneObject sceneObject);
    void Render();
    void Dispose();
}