# gmusicapiCSharp
A C# wrapper for gmusicapi with IronPython

This experiment tries to use the (mainly) unmodified [gmusicapi](https://github.com/simon-weber/gmusicapi)
and make it available in C#

This project has just started so the are only a few functions implemented (mainly Mobileclient).
The Demo should work so far but there are currently no other tests.

### Setup
The IronPython setup is a pain.
Please refer to the [install instructions](https://github.com/ffleischer/gmusicapiCSharp/blob/master/INSTALL%20GMUSICAPI%20ON%20IRONPYTHON.txt)

This whole process is a first draft and need's some work. 
With some luck it works but it will probably break some stuff.
A preconfigured IronPython package is available [here](https://mega.nz/#!2R5BBSIS!SfdNpcflEWb8pX7I1eWM7VD5p3JlmmhgIi_NxQ07xmg)

### ToDo
- rework setup process
  - less hacking, maybe some kind of sript or patch files
  - try to compile the IronPython Module into a dll
- cast C# Types to Python Types
- error handling
- implement missing clients, types and functions
- test
- documentation
