# Class Diagrams

This document contains class diagrams for the core components of TheChest project.

## IContainer Diagram

The `IContainer` diagram represents a generic container interface that holds slots for items.

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
	namespace TheChest.Core.Containers.Interfaces {
        class IContainer~T~ {
	        +ISlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
        }
	}
	namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
	        +bool IsEmpty
	        +bool IsFull
        }
	}
	namespace TheChest.Core.Containers {
        class Container~T~ {
        }
	}
	namespace TheChest.Core.Slots {
        class Slot~T~ {
        }
	}

	<<interface>> IContainer
	<<interface>> ISlot

    Container --|> IContainer : implements
    ISlot --* IContainer
    Slot --|> ISlot : implements
```

## IStackContainer Diagram
The `IStackContainer` diagram represents a generic container interface that supports stackable slots, allowing multiple items from the same type to be stored in a single slot.

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
	namespace TheChest.Core.Containers.Interfaces {
		class IStackContainer~T~ {
	        +IStackSlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
        }
	}
	namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
	        +bool IsEmpty
	        +bool IsFull
        }
        class IStackSlot~T~ {
            +int StackAmount
            +int MaxStackAmount
        }
	}
	namespace TheChest.Core.Containers {
		class StackContainer~T~ {
        }
		class StackSlot~T~{
			-int stackAmount
			-int maxStackAmount
		}
	}

	<<interface>> IStackContainer
    <<interface>> IStackSlot

    StackContainer --|> IStackContainer : implements
    IStackSlot --|> ISlot : implements
    StackSlot --|> IStackSlot : implements
    IStackSlot --* IStackContainer
```

## ILazyStackContainer Diagram
The `ILazyStackContainer` diagram represents a generic container interface that supports lazy loading of stackable slots, allowing multiple items from the same type to be stored in a single slot.
```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
```