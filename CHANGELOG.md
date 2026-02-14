# v0.15.3

## What's changed
* Field `content` doesn't have Nullable type anymore in `Slot<T>`, `StackSlot<T>` and `LazyStackSlot<T>`

## Known Issues
* Unit tests project is running on .net 6.0 while the main project is on .net standard 2.1

## What's Next
* [#127](https://github.com/The-Chest/TheChest.Core/issues/127) - More ways to instantiate the Container classes 
* [#140](https://github.com/The-Chest/TheChest.Core/issues/140) - New Property `AvailableAmount` to `StackSlot<T>` and `LazyStackSlot<T>` 

* **Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.15.2...v0.15.3

# v0.15.2

## What's Fixed
* `StackContainer<T>.Contains(T item, int amount)` now count all items in all slots to compare with `amount` instead of one for each slot.

## What's Removed
* Useless amount validation on `StackSlot<T>.Contains(T item)`

## Known Issues
* Unit tests project is running on .net 6.0 while the main project is on .net standard 2.1

## What's Next
* [#127](https://github.com/The-Chest/TheChest.Core/issues/127) - More ways to instantiate the Container classes 
* [#123](https://github.com/The-Chest/TheChest.Core/issues/127) - DLL file to release 

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.15.1...v0.15.2

# v0.15.1

## What's Fixed
* `StackContainer<T>.Contains` methods are now virtual.

## What's Changed
* XML docs improved on the classes and interfaces

## What's Next
* [#127](https://github.com/The-Chest/TheChest.Core/issues/127) - More ways to instantiate the Container classes 
* [#123](https://github.com/The-Chest/TheChest.Core/issues/127) - DLL file to release 

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.15.0...v0.15.1

# v0.15.0

## What's Added
* `.editorconfig` with code style rules
    * `Nullable` enabled for the project 
* Slots now have a private field named `content`
    * It can stores the content from constructor and be `nullable`
* Attribute for unit tests (`[IgnoreIfReferenceType]` and `[IgnoreIfValueType]`)
* Slots now have static Valitation methods to be used in constructors
  * `StackSlot<T>`
    * `ValidateContent(T[] items, int maxAmount)` - Validates that `items` array is not null or empty and does not exceed `maxAmount`.
    * `ValidateAmount(int amount, int maxAmount)` - Validates that `amount` is within the allowed range from zero to `maxAmount`.
  * `LazyStackSlot<T>`
    * `ValidateAmount(int amount, int maxAmount)` - Validates that `amount` is within the allowed range from zero to `maxAmount`.
* `MaxAmount` and `Amount` now calls the static Validation methods in its constructors

## What's Changed
* Slots now supports reference and value types.

## Known issues
* Unit test project is a mess...

## What's Next
* [#127](https://github.com/The-Chest/TheChest.Core/issues/127) - More ways to instantiate the Container classes 
* [#122](https://github.com/The-Chest/TheChest.Core/issues/122) - XML docs descriptions of the interfaces and some properties are not describing improvements 

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.14.0...v0.15.0

# v0.14.0

## What's Removed
* Removed `this[index]` from `IContainer`,`IStackContainer` and `ILazyStackContainer`
* Removed `this[index]` from `Container`,`StackContainer` and `LazyStackContainer`

## What's next
* Aiming to release `TheChest.Core` v1.0.0 on the next release

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.13.0...v0.14.0

# v0.13.0

## What's Changed
* Improve tests by separating interfaces and implementation 
* Improve the package building

## Known issues
* No better way to instantiate the classes (Thinking about adding a Factory)

## What's next
* Maybe the Container structure can be unified (the interface part at least) and the implementation can decide about how to handle it
  * Check how this would affect `TheChest.Inventories`

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.12.1...v0.13.0

# v0.12.0

## What's Changed
* `Contains` methods for all Inventory classes are now part of its interfaces contracts

## What's Fixed
* `Contains` methods in all Slot classes are now marked as `virtual`

## Known issues
* [#100](https://github.com/The-Chest/TheChest.Core/issues/100) - Interfaces and implementations are sharing the same test scenarios
* No better way to instantiate the classes (Thinking about adding a Factory)

## What's next
* Maybe the Container structure can be unified (the interface part at least) and the implementation can decide about how to handle it
  * Check how this would affect `TheChest.Inventories`
  
**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.11.0...v0.12.0

# v0.11.0

## What's Added
* `ILazyStackSlot<T>` and  `ILazyStackContainer<T>` interfaces
  * Separated unit tests for both
  * Docs also added to it

## Known issues
* [#100](https://github.com/The-Chest/TheChest.Core/issues/100) - Interfaces and implementations are sharing the same test scenarios
* [#101](https://github.com/The-Chest/TheChest.Core/issues/101)  - Slots `Contains` method not marked as `virtual`
* [#94](https://github.com/The-Chest/TheChest.Core/issues/94) - Containers `Contains` method not inside interface contract

## What's next
* Maybe the Container structure can be unified (the interface part at least) and the implementation can decide about how to handle it
  * Check how this would affect `TheChest.Inventories`

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.10.0...v0.11.0

# v0.10.0

## What's Added
* Protected field `amount` that is initialized as a result of checking which contents from the `items` parameter are not `null`

## What's Changed
* The API properties `StackAmount` and `MaxStackAmount` from `IStackSlot<T>` now do not have the `Stack` part of it
* `Amount` returns the value from `amount` and cannot be bigger than `MaxAmount` or less than zero
* `StackSlot<T>.IsFull` now checks for `Amount` and `MaxAmount` properties instead of the protected fields 

## Known issues
* [#87](https://github.com/The-Chest/TheChest.Core/issues/87) - `LazyStackSlot` structure needs some adjustments
* [#100](https://github.com/The-Chest/TheChest.Core/issues/100) - Interfaces and implementations are sharing the same test scenarios

# v0.9.1

## What's Fixed
* `readonly` removed from the field `content` in Slot, StackSlot and LazyStackSlot classes

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#87](https://github.com/The-Chest/TheChest.Core/issues/87) - `LazyStackSlot` structure needs some adjustments

**Full Changelog**: https://github.com/The-Chest/TheChest.Core/compare/v0.9.0...v0.9.1

# v0.9.0

## What's Added
* `StackSlot.Contains(T[] items)` method
* Obsolete methods (do not use it)
  * `LazyStackSlot.Contains(T[] items)` - Use `LazyStackSlot.Contains(T item, int amount)` 
  * `StackSlot.Contains(T item, int amount)` - Use `StackSlot.Contains(T[] items)`
* Slot classes now have `content` protected field

## What's Changed
* `LazyStackSlot` is now holding only one item 
* `IStackSlot` and `ISlot` are now contravariant
* `Contains` extensions methods moved to interface and its class implementations
  * `Contains(T item, int amount)` extension method moved to `IStackSlot`
  * `Contains(T item)` extension method moved to `ISlot`

## What's Removed
* `Slots` property from `Container` interfaces and classes
* `Content` property from `Slot` interfaces and classes

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#87](https://github.com/The-Chest/TheChest.Core/issues/87) - `LazyStackSlot` structure needs some adjustments

# v0.8.0

## What's Added
* Summary docs finished

## What's Changed
* Project now is using .net standard v2.1

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#58](https://github.com/The-Chest/TheChest.Core/issues/58) - LazyStackSlot is holding multiple items instead of one

# v0.7.1

## What's Added
* Now every class/interface have its own summary doc on nuget.pkg

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#24](https://github.com/The-Chest/TheChest.Core/issues/24) - Project .net version outdated

# v0.7.0

## What's Added
* `IStackContainer` and `IContainer` extension method `Contains<T>(T item, int amount)`
## What's Changed
* `IStackSlot` extension method `Contains<T>(T item)` now has an `int amount = 1` param

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#24](https://github.com/The-Chest/TheChest.Core/issues/24) - Project .net version outdated

# v0.6.0

## What's Changed
* `IStackSlot<T>.Content` type is no longer `Array<T>` but instead `IReadOnlyCollection<T>`
  * It affected all implementations of `IStackSlot<T>`
* Slots property type in Containers were changed from `Array` to `IReadOnlyCollection`
  * `Container<T>.Slots` type from `ISlot<T>[] type` to `IReadOnlyCollection<ISlot<T>>`
  * `StackContainer<T>.Slots` type from `IStackSlot<T>[] type` to `IReadOnlyCollection<IStackSlot<T>>`
* Added protected field `slots` to `Container<T>` and `StackContainer<T>`

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#24](https://github.com/The-Chest/TheChest.Core/issues/24) - Project .net version outdated

# v0.5.0

## What's Added
* Adds `Contains` extension methods to Slots and Containers
* Adds test coverage and build Pipelines 
* Adds basic documentation to the project 

## Known issues
* [#20](https://github.com/The-Chest/TheChest.Core/issues/20) - `StackSlot` constructor with no validation
* [#24](https://github.com/The-Chest/TheChest.Core/issues/24) - Project .net version outdated

# v0.4.0

## What's Added
* `ILazyStackSlot<T>`
  * Lazy Slots only needs a single instance of an item, and more are generated/returned based on the amount value set.

## What's Changed
* Factory classes now have `virtual` method modifier for all methods.
* Factory classes now have `CreateDefault` and `CreateRandom`
* Slot and Container namespaces interface from `Generics` to `Interfaces` 
* `ISlot<T>.Content` is now Nullable
* `IStackSlot<T>.Content` type from `ICollection<T>` to `T[]`
* `StackContainer<T>` now have `virtual` method modifier for all properties

## What's Removed
* `TheChest.Core.Inventories` removed from the project
* `Base` from abstract from Slots and Containers
* All Inventory features. 
  * Go to [TheChest.Inventories](https://github.com/The-Chest/TheChest.Inventories) to use any inventory features.
 
# v0.3.0

## What's Added
* `Inventory<T>` implements `IInventory<T>` 
  * A container that permit to change its contents 
* `InventorySlot<T>` implements `IInventorySlot<T>`
  * A Slot that permit to change its contents

## What's Changed
* Removed obsolete from 
  * `IInventory<T>`
  * `IInteractiveContainer<out T>`
  * `IStackInventory<T>`
* `CreateRandom` and `CreateManyRandom` methods to `SlotItemFactory`
* Example project folder structure 
* `ISlot<T>.Content` now returns `T?`
* `InventorySlotEventType` references removed for now
* `ISlotItemFactory.CreateItem` is now called `ISlotItemFactory.CreateDefault`

## Known Issues
* https://github.com/The-Chest/the-chest-core/issues/12 -` IStackSlot<T>` and `ILazyStackSlot<T>` tests not working together

# v0.2.0

## What's Added
* `Inventory<T>` implements `IInventory<T>` 
  * A container that permit to change its contents 
* `InventorySlot<T>` implements `IInventorySlot<T>`
  * A Slot that permit to change its contents

## What's Changed
* Removed obsolete from 
  * `IInventory<T>`
  * `IInteractiveContainer<out T>`
  * `IStackInventory<T>`
* `CreateRandom` and `CreateManyRandom` methods to `SlotItemFactory`
* Example project folder structure 
* `ISlot<T>.Content` now returns `T?`
* `InventorySlotEventType` references removed for now
* `ISlotItemFactory.CreateItem` is now called `ISlotItemFactory.CreateDefault`

## Known Issues
* https://github.com/The-Chest/the-chest-core/issues/12 -` IStackSlot<T>` and `ILazyStackSlot<T>` tests not working together

# v0.1.1

## What's Added
* Unit tests to `BaseContainer<T>` and `BaseStackContainer<T>`
* Unit tests to `BaseSlot<T>` and `BaseStackSlot<T>`
* Example projects - `TheChest.Example.ConsoleApp`

## What's Changed
* `BaseStackSlot<T>(T[] items, int maxStack)` now calls base class constructor `BaseSlot<T>(T item)` 

## Known Issues
* No documentation yet
* No unit tests to Inventory features yet

# v0.1.0

## What's Added
* Base project architecture migrated from [the-chest-unity](https://github.com/The-Chest/the-chest-unity)
  * Base classes
    * `BaseContainer<T>` - Generic container with `IContainer<T>` implementation
    * `BaseStackContainer<T>` - Generic container with `IStackContainer<T>` implementation
    * `BaseInventory<T>` - Generic Inventory with `IInventory<T>` implementation
    * `BaseStackInventory<T>` - Generic Inventory with `IStackInventory<T>` implementation
    * `BaseInventorySlot<T>` - Generic Slot Inventory with `IInventorySlot<T>` implementation
    * `BaseInventoryStackSlot<T>` - Generic Slot Inventory with `IStackInventorySlot<T>` implementation
  * Interfaces 
    * `IContainer<T>` - Interface with basic features of a Container with `ISlot<T>` slots
    * `IStackContainer<T>` - Interface with basic features of a Container with `IStackSlot<T>` slots
    * `IInteractiveContainer<T>` - Interface with methods for interaction with the Container
    * `IInventory<T>` - Interface with methods for interaction with the Inventory with `IInventorySlot<T>` slots
    * `IStackInventory<T>` - Interface with methods for interaction with the Inventory using `IInventoryStackSlot<T>` slots
    * `ISlot<T>` - Interface with properties for a basic Slot
    * `IStackSlot<T>` - Interface Container with properties for a basic Stack Slot
    * `IInventorySlot<T>` - Interface with methods for a basic Inventory Slot
    * `IInventoryStackSlot<T>` - Interface with methods for a basic Inventory Stackable Slot 
## Known Issues
* No documentation yet
* No unit tests yet
