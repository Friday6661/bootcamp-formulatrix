# Acces Modifier in C#

## 1. Access Modifiers

Access modifiers will provides accessibility of All type members. The accesibility level control whether they can be used from other code in your assembly or other assemblies. Below are access modifiers to specify the accessibility:

### a. Private

The type or member can be accessed only by code in the same class or struct.

### b. Public

The type or member can be accessed by any other code in the same assembly or another that references it.

### c. Protected

The type or member can be accessed only by code in the same class, or in a class that is derived from that class

### d. Internal

Acces is limited to the current assembly

### e. Protected Internal

A protected internal member is accessible from the current assembly or from types that are derived from the containing class.
