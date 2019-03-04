# CPUSimulator
C# Classes to Simulate Various CPU Scheduling Algorithms

## Inheritance Map
```
Processor
+--FCFSProcessor
+--SJNProcessor
+--SRTProcessor
+--RRProcessor
```

## Dependancy Map
```
+Job
  +Processor
    +FCFSProcessor
    +SJNProcessor
    +SRTProcessor
    +RRProcessor
  +Simulator
    +Processor
```

## Classes

### Program
This is the driver class for our program, it is not important for discussions of the algorithms used.

### Processor
This abstract class is the base for any processor implementations. The only function that needs to be overridden is the cycle method, which simulates what occurs in a cpu cycle for that processor.

### FCFSProcessor
This class is used to simulate the first come first serve method of CPU scheduling. The algorithm is simple, not adjusting the waiting queue unless the current job has finished.

### SJNProcessor
This class simulates the Shortest Job Next algorithm. It works by always looking at the first element in the list, and sorting the list when the current job finishes.

### SRTProcessor
This class simulates the Shortest Remaining Time algorithm. It works similarly to the SJN algorithm, but sorts every cycle rather than when a job finishes. This would be much more effecient if implemented as a priority queue.

### RRProcessor
This class simulates the Round Robin algorithm. Its implementation is built on the FCFS, but requires a timer and time quantum. Instead of only adjusting the index when a job finishes, it also occurs when the timer reaches the time quantum.

### Simulator
This class contains the methods needed to drive a processor simulation. It facilitates not adding jobs until the appropriate time, allowing the processor algorithms to be closer to actual implementations (they don't know what they will be getting in the future).

### InputParser
This class is used to parse job files or jobs from the console for the simulations.

### Job
This class is a data representation of a job, and could allow the implementation of an interactive job as it contains its own cycle method.
