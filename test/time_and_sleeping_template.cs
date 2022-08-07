// show time points, durations, and clocks

// there are LOTS of things to do with dates but we need to focus
// making a timepoint from now or a fixed local time
// turning a timepoint back into parts like for printing
// constructing a duration
// doing math on a duration
// doing math on a timepoint by applying a duration
// measuring the duration something took
// creating a timer loop
// printing a time progression

// not shown yet
// how to format date and time

// use 64 bit numbers where possible to avoid year 2038 problem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpPracticeSyntax
{
    public class TimeAndSleepintTests
    {
        [Fact]
        void Test1()
        {
            // construct a time_point from a fixed time
            {
                // Convert std::tm to std::time_t 
                // Convert std::time_t to std::chrono::system_clock::time_point

                //convert back to time_t just for printing
            }
            // construct a time_point from current time and then print it
            {
            }
            // create a 5 second duration and add 2500 milliseconds
            {
                // create a 5 second duration
                // convert it to milliseconds
                // add 2500 milliseconds
                // convert back to seconds, truncating if necessary
            }
            // break up a duration into days and hours and minutes and seconds and subseconds
            {
                //std::chrono::system_clock::duration dtn = now_time_point.time_since_epoch();


                //unsigned long long seconds_since_1970 = std::chrono::seconds(dtn).count();
            }

            // measure a duration with the high resolution clock
            {
                // record start time
                // do some work
                // record end time
                // the diff.count() is the number of seconds and fractions of a second
            }
            // measure a duration with the system clock of a 3 second sleep 
            {
                // the elapsed_seconds.count() is the number of seconds and fractions of a second
            }

            // convert that number of seconds to an hours minutes seconds in local time zone
            // convert that duration to a time_t

            // loop with wakeup every 5 seconds no matter how long it takes to do the work each time.
            {
                // get the next wakeup time 5 seconds later than now, not necessarily on a 5 second boundary (00, 05, 10)

                // here you would do some unpredictably slow work

                // sleep until the next wakeup time.  It doesn't matter how long the unprecitable slow work took as long as it was < 5 seconds

                // print the current time to show we are waking up 5 seconds apart
            }

            // make a loop that clears the console window and prints one timer counting up and one timer counting down.  Format the timer as hours:minutes:seconds
            // show a countdown timer from 10 to 1

            // compute the next wakeup time_point 1 second later than now

            // format some times
            // print the countdown
            // sleep until the next wakeup time 
        }
    }
}