# Physics Bug

This project details the incorrect calculation of rigid body positions in Unity physics updates.

Open the `SuvatBug` scene and press play. The balls will attempt to reach a height $H$ of 1.7m. The following equation is used to calculate the required upward velocity for all of the balls:

$$u = \sqrt{-2gH}$$

The ball on the left uses the standard `SUVAT` equation to manually update the ball's position:

$$s = ut + \frac{1}{2}at^2$$

The ball in the middle uses Unity physics. And the ball on the right also uses Unity physics but with a correcting adjustment made to the impulse force.

For the derivation of the correcting adjustment see my [blog post](https://blog.powered-up-games.com/wordpress/archives/438) on the subject.

When the balls land, they output how short they fall from reaching the target height:

```
SUVAT short by 0.037cm
UnityPhysics short by 5.7cm
UnityPhysicsCorrected short by 0.037cm
```

As you can see, the Unity physics solution falls well short of the target, whereas the standard SUVAT version and corrected physics match results and get much closer.

To output the positions frame by frame to the console, uncomment the `Debug.Log` lines at line 30 of `UnityPhysics.cs` and line 25 of `ManualSuvat.cs`.

You should notice that the corrected Unity physics position tracks SUVAT version almost exactly.