using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: All items should be added to the back of the queue
    // in the same order they were enqueued.
    // Test Result: Passed.
    // Defect(s) Found: None. Enqueue correctly adds items to the back.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual(
            "[A (Pri:1), B (Pri:3), C (Pri:2)]",
            priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue two items and dequeue the highest-priority item.
    // Then dequeue again.
    // Expected Result: A should be returned first and B should be returned
    // second because A should be removed during the first dequeue.
    // Test Result: Failed before correction; passed after correction.
    // Defect(s) Found: Dequeue returned the selected value but did not
    // remove the corresponding item from the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue three items where the last item has the highest priority.
    // Expected Result: C should be dequeued because it has priority 5.
    // Test Result: Failed before correction; passed after correction.
    
    // Defect(s) Found: The original loop did not examine the last item.
    public void TestPriorityQueue_HighestPriorityAtBack()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority.
    // Expected Result: A should be removed before B because A entered first.
    // Test Result: Failed before correction; passed after correction.
    // Defect(s) Found: The original comparison used >=, causing the later
    // equal-priority item to be selected instead of following FIFO.
    public void TestPriorityQueue_EqualPriorityUsesFifo()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with
    // the message "The queue is empty."
    // Test Result: Passed.
    // Defect(s) Found: None. The correct exception and message were produced.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                $"Unexpected exception of type {e.GetType()} caught: {e.Message}"
            );
        }
    }
}