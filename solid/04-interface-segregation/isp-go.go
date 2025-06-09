/*
Interface Segregation Principle (ISP)
-------------------------------------
Clients should not be forced to depend on interfaces they do not use.

This principle encourages splitting large, general-purpose interfaces into
smaller, more specific ones. This improves flexibility and reduces the
need for dummy or empty implementations in classes that don't require all behaviors.

✅ A class should only implement the methods it actually needs.
✅ ISP helps maintain a clean and modular system, especially when combined with patterns like Strategy or Factory.
*/

package main

import "fmt"

// Bad example
type MultiFunctionDevice interface {
	Print(document string)
	Scan(document string)
	Fax(document string)
}

// implicit interface implementation: Go knows that OldPrinter implements MultiFunctionDevice

type OldPrinter struct{}

func (o OldPrinter) Print(document string) {
	fmt.Println("Printing:", document)
}

func (o OldPrinter) Scan(document string) {
	// 👎 OldPrinter can't scan, but must implement the method
	fmt.Println("Scan not supported")
}

func (o OldPrinter) Fax(document string) {
	// 👎 Same problem here
	fmt.Println("Fax not supported")
}

// same example with c# must be explicit
// public class OldPrinter : IMultiFunctionDevice
// {
//     public void Print(string doc) { ... }
//     public void Scan(string doc) { ... }
//     public void Fax(string doc)  { ... }
// }

// Example 2 : two interfaces
// Interface 1: Notifier
type Notifier interface {
	Notify(message string)
}

// Interface 2: Printer
type Printer interface {
	Print(document string)
}

// Struct implementing both
type LaserPrinter struct{}

func (lp LaserPrinter) Print(document string) {
	fmt.Println("LaserPrinter printing:", document)
}

func (lp LaserPrinter) Notify(message string) {
	fmt.Println("LaserPrinter notification:", message)
}

// Example 3: interface composition

// Individual interfaces (already implemented in example 2)
// type Printer interface {
// 	Print(document string)
// }

// type Notifier interface {
// 	Notify(message string)
// }

// Interface composition (ISP + Go idiom)
type SmartDevice interface {
	Printer
	Notifier
}

// Struct that implements both Printer and Notifier
type SmartLaserPrinter struct{}

func (s SmartLaserPrinter) Print(document string) {
	fmt.Println("SmartLaserPrinter printing:", document)
}

func (s SmartLaserPrinter) Notify(message string) {
	fmt.Println("SmartLaserPrinter notification:", message)
}

// Function that uses the composed interface
func UseSmartDevice(device SmartDevice) {
	device.Print("Monthly Report")
	device.Notify("Report printed successfully")
}

func main() {
	// Example 2
	var p Printer = LaserPrinter{}
	p.Print("Annual Report")

	var n Notifier = LaserPrinter{}
	n.Notify("Print job complete")

	// Example 3
	device := SmartLaserPrinter{}
	UseSmartDevice(device)
}
