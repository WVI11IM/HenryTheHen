itch.io page: https://wvi11im.itch.io/henry-the-hen

In this 2D top-down shooter mobile game, you control Henry, a chicken that got locked out of the chicken coop at night and now must survive the predators, collect items and shoot eggs to get himself out of this mess!

There are 6 levels in total, which are split into 3 different objectives: Survival (survive for an amount of time), Search and Destroy (defeat an amount of enemies) and Rescue (rescue an amount of chicks and bring all of them to the chicken coup).

The core mechanic of this game are Henry's movement and attack, which are linked together in a way that the player has to aim the egg being shot and use the recoil to move the chicken to the opposite direction.

Contributions:
- Movement: Rigidbody2D + AddForce() + Direction of input. Code for implementation below.
- Enemies: A* Pathfinding, different attack and health stats, patterns for movement and behaviour, such as mud slimes exploding when defeated and bats flying over obstacles.
- Level Design: Creation with Unity Tilemaps + Obstacles such as spiny bushes that do damage on collision and mud pits that temporarily slows down the chicken's movement.
- Power-ups and items: Power-ups for healing and invincibility. Eggs with different properties, such as explosive eggs with area damage, ice eggs with freeze effect, ghost eggs that can pierce through obstacles, and others, all with their own damage, speed and recoil values.
- In-game currency system: Enemies can drop corn, which can be used to purchase skins.
