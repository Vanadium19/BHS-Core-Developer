using BHS.View;
using BHS.View.SceneObjects;

namespace BHS.Components;

/// <summary>
/// Компонент, связывающий ECS-сущность с визуальным объектом сцены.
/// </summary>
/// <remarks>
/// <para>
/// Содержит ссылку на объект, унаследованный от <see cref="SceneObject"/>,
/// что позволяет системам напрямую обновлять визуальное состояние.
/// </para>
/// </remarks>
public struct LinkToSceneObject
{
    public SceneObject Value;
}