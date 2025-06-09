// Bad example

// class Bird {
//     fly(): void{
//         console.log("Flying...");
//     }
// }

// class Ostrich extends Bird{
//     fly(): void{
//         throw new Error("I cant't fly");
//     }
// }

// Good example:
/**
 * Liskov Substitution Principle (LSP)
 * -----------------------------------
 * Subtypes must be substitutable for their base types without breaking the application.
 * 
 * ⚠️ A violation occurs when a subclass overrides behavior in a way that contradicts
 *    the expectations set by the parent class.
 * 
 * ✅ To follow LSP, use interface segregation to separate incompatible behaviors.
 *    This ensures that derived types can always be used in place of their base types.
 */

interface Bird{
    eat(): void;
}

interface FlyingBird extends Bird{
    fly(): void;
}

class Sparrow implements FlyingBird{
    fly(): void{
        console.log("Sparrow flying");
    }
    eat(): void {
        console.log("Sparrow eating");
    }
}

class Pinguin implements Bird{
    eat(): void{
        console.log("Pinguin eating");
    }
}


// Example 2

// Step 1 – Create a base interface for all vehicles
interface Vehicle {
  move(): void;
}

// Step 2 – Create a specialized interface for flying vehicles
interface Flyable {
  fly(): void;
}

// Step 3 – Create classes that implement the correct interfaces

class Car implements Vehicle {
  move(): void {
    console.log("Car is moving on the road");
  }
}

class Airplane implements Vehicle, Flyable {
  move(): void {
    console.log("Airplane is taxiing");
  }

  fly(): void {
    console.log("Airplane is flying");
  }
}

// Step 4 – Function that expects any Vehicle
function travel(vehicle: Vehicle) {
  vehicle.move();
}

// Step 5 – Function that expects only Flyable things
function takeOff(flyer: Flyable) {
  flyer.fly();
}

// Step 6 – Test the substitution principle

const myCar = new Car();
const myPlane = new Airplane();

travel(myCar);   // ✅ Works
travel(myPlane); // ✅ Works

takeOff(myPlane); // ✅ Works
// takeOff(myCar); // ❌ Compilation error – as expected!


/**
 * Why this is not a Strategy Pattern
 * ----------------------------------
 * This example demonstrates the Liskov Substitution Principle (LSP), not the Strategy Pattern.
 * 
 * In LSP, subclasses are expected to preserve the behavior of their base types. Here,
 * we separate interfaces (Vehicle, Flyable) to avoid forcing subclasses like Car to 
 * implement behavior they don't support, such as flying.
 * 
 * In contrast, the Strategy Pattern is about encapsulating interchangeable algorithms
 * or behaviors, typically injected at runtime to delegate functionality.
 * 
 * In this example:
 * - We are not injecting behaviors.
 * - We are not dynamically switching logic.
 * - Each class defines its own concrete behavior directly.
 * 
 * Therefore, this is an example of applying LSP and Interface Segregation Principle,
 * not Strategy.
 */