# Physics Bug

This project details the incorrect calculation of rigid body positions in Unity physics updates.

Open the `SuvatBug` scene and press play. The balls will attempt to reach a height $H$ of 10m. The following equation is used to calculate the required upward velocity for all of the balls:

$$u = \sqrt{-2gH}$$

The ball on the left uses the correct `SUVAT` equation to manually update the ball's position:

$$s = ut + \frac{1}{2}at^2$$

The ball in the middle uses Unity physics. And the ball on the right uses an incorrect `SUVAT` equation to manually update the ball's position:

$$s = ut + at^2$$

When the balls land, they output the height they reached to the console:

```
IncorrectSuvat hits peak of 9.860386m
CorrectSuvat hits peak of 9.999687m
UnityPhysics hits peak of 9.860385m
```

As you can see, the incorrect equation almost exactly matches the Unity physics and both fall well short of the 10m target.

To output the positions frame by frame to the console, uncomment the `Debug.Log` lines at line 22 of `UnityPhysics.cs` and line 24 of `ManualSuvat.cs`.

You should notice that the Unity physics position tracks the ball using the incorrect equation almost exactly.