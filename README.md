# Babsitter Kata

This is my take on Pillar Technology's Babysitter Payment Kata. You can read up on this specific kata [here](https://github.com/PillarTechnology/kata-babysitter).

## Prerequisites
- Familiarity and general knowledge of how to clone a repository and use Git.
- [Git Tools Installed](https://git-scm.com/downloads)
- [.NET Core Installed](https://dot.net/)

### Configuting Your Environment

```
dotnet restore
```

### Run Tests

```
dotnet test BabySitter.Tests
```

### Run Console Application
To run the Application execute the following command:
```
dotnet run --project BabySitter.App
```

#### What I've Learned...
- TDD makes you craft a blueprint of what your code is going to do. Often times when not using TDD you just write code as you find out you need it. For example, without TDD a group of men would go about paving a road without a clear idea of what is ahead of them. They may reach a valley and need materials for a bridge and that would come as an unexpected 'surprise'. With TDD, a group of men would know that valley is ahead of them and come prepared with the materials and machinery needed to build a bridge.
- Also, TimeSpan is a no go in the future. DateTime would have made things much easier... That's the point of a kata though right? To learn.