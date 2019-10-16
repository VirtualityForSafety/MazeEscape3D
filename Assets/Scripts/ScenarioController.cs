using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tasc
{
    public class ScenarioController : MonoBehaviour
    {
        bool isTerminusExported = false;
        bool isActionExported = false;
        Scenario scenario = new Scenario("Maze escape", "A user is required to memorize a way to get the goal point.");

        public List<Interface> interfaces;
        public Actor actor;

        // Use this for initialization
        void Start()
        {
            InitializeScenario();

        }

        void InitializeScenario()
        {
            MakeTestScenario();
        }

        void MakeTestScenario()
        {
            ////////////// actor null exception 
            CrossroadPoint cp1 = GameObject.Find("CrossroadPoint1").GetComponent<CrossroadPoint>();
            CrossroadPoint cp2 = GameObject.Find("CrossroadPoint2").GetComponent<CrossroadPoint>();
            CrossroadPoint cp3 = GameObject.Find("CrossroadPoint3").GetComponent<CrossroadPoint>();
            CrossroadPoint cp4 = GameObject.Find("CrossroadPoint4").GetComponent<CrossroadPoint>();
            CrossroadPoint cp5 = GameObject.Find("CrossroadPoint5").GetComponent<CrossroadPoint>();
            CrossroadPoint goal = GameObject.Find("Goal").GetComponent<CrossroadPoint>();
            //*

            Task introduction = new Task("Intro", "");
            introduction.instruction = new Instruction(introduction.name);
            introduction.instruction.SetContentWithContext("Tutorial", Information.Context.Title);
            introduction.instruction.SetContentWithContext("Hi. Maze escape training is just started. In this training you are asked to remember five choices of right direction at crossroads.", Information.Context.Narration);
            introduction.instruction.SetContentWithContext("Hi. Maze escape training is just started. In this training you are asked to remember five choices of right direction at crossroads.", Information.Context.Description);
            //introduction.exit = new Condition(new TaskState(introduction, TaskProgressState.Started), Condition.Operator.Equal, new TimeState(0,0,1));
            introduction.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp1), 7.0f), Condition.RelationalOperator.SmallerOrEqual);
            scenario.Add(introduction);

            Task task1 = new Task("Task1", "");
            //task1.instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            task1.instruction = new Instruction(task1.name);
            task1.instruction.SetContentWithContext("Stage 1", Information.Context.Title);
            task1.instruction.SetContentWithContext("This is the first crossroad. Please follow to the direction with the tomato picture.", Information.Context.Narration);
            task1.instruction.SetContentWithContext("This is the first crossroad. Please follow to the direction with the tomato picture.", Information.Context.Description);
            task1.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp2), 7.0f), Condition.RelationalOperator.SmallerOrEqual);
            //task1.exit = new Condition(new TaskState(task1, TaskProgressState.Started), Condition.Operator.Equal, new TimeState(0, 0, 1));
            scenario.Add(task1);

            Task task2 = new Task("Task2", "");
            //task1.instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            task2.instruction = new Instruction(task2.name);
            task2.instruction.SetContentWithContext("Stage 2", Information.Context.Title);
            task2.instruction.SetContentWithContext("This is the second crossroad. Please follow to the direction with the blue bird picture.", Information.Context.Narration);
            task2.instruction.SetContentWithContext("This is the second crossroad. Please follow to the direction with the blue bird picture.", Information.Context.Description);
            task2.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp3), 7.0f), Condition.RelationalOperator.SmallerOrEqual);
            scenario.Add(task2);

            Task task3 = new Task("Task3", "");
            //task1.instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            task3.instruction = new Instruction(task3.name);
            task3.instruction.SetContentWithContext("Stage 3", Information.Context.Title);
            task3.instruction.SetContentWithContext("This is the third crossroad. Please follow to the direction with the yellow car picture.", Information.Context.Narration);
            task3.instruction.SetContentWithContext("This is the third crossroad. Please follow to the direction with the yellow car picture.", Information.Context.Description);
            task3.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp4), 7.0f), Condition.RelationalOperator.SmallerOrEqual);
            scenario.Add(task3);

            Task task4 = new Task("Task4", "");
            //task1.instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            task4.instruction = new Instruction(task4.name);
            task4.instruction.SetContentWithContext("Stage 4", Information.Context.Title);
            task4.instruction.SetContentWithContext("This is the fourth crossroad. Please follow to the direction with the bitcoin picture.", Information.Context.Narration);
            task4.instruction.SetContentWithContext("This is the fourth crossroad. Please follow to the direction with the bitcoin picture.", Information.Context.Description);
            task4.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp5), 7.0f), Condition.RelationalOperator.SmallerOrEqual);
            scenario.Add(task4);

            Task task5 = new Task("Task5", "");
            //task1.instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            task5.instruction = new Instruction(task5.name);
            task5.instruction.SetContentWithContext("Stage 5", Information.Context.Title);
            task5.instruction.SetContentWithContext("This is the fifth crossroad. Please follow to the direction with the grayscale cup picture.", Information.Context.Narration);
            task5.instruction.SetContentWithContext("This is the fifth crossroad. Please follow to the direction with the grayscale cup picture.", Information.Context.Description);
            task5.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(goal), 7.0f), Condition.RelationalOperator.SmallerOrEqual);
            scenario.Add(task5);

            Task ending = new Task("Finish", "");
            ending.instruction = new Instruction(ending.name);
            ending.instruction.SetContentWithContext("Finish", Information.Context.Title);
            ending.instruction.SetContentWithContext("Well done! Your training is successfully terminated.", Information.Context.Narration);
            ending.instruction.SetContentWithContext("Well done! Your training is successfully terminated.", Information.Context.Description);
            ending.exit = new Condition(new InputUpState(actor, (int)KeyCode.C), Condition.RelationalOperator.Equal);
            scenario.Add(ending);

            scenario.MakeProcedure();

            scenario.Activate();
        }

        // Update is called once per frame
        void Update()
        {
            if (scenario != null)
                scenario.Proceed(interfaces);
        }
    }
}

