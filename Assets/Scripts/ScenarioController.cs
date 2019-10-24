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
        ProceduralScenario scenario = new ProceduralScenario("Maze escape", "A user is required to memorize a way to get the goal point.");

        public List<TransferElement> interfaces;
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
            Instruction introductionInstruction = new Instruction(introduction.name, interfaces);
            introductionInstruction.SetContent("Title", "Tutorial");
            introductionInstruction.SetContent("Narration", "Hi. Maze escape training is just started. In this training you are asked to remember five choices of right direction at crossroads.");
            introductionInstruction.SetContent("Description", "Hi. Maze escape training is just started. In this training you are asked to remember five choices of right direction at crossroads.");
            //introduction.exit = new Condition(new TaskState(introduction, TaskProgressState.Started), Condition.Operator.Equal, new TimeState(0,0,1));
            introduction.AddInstruction(introductionInstruction);
            introduction.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp1), 7.0f), RelationalOperator.SmallerOrEqual);
            scenario.Add(introduction);

            Task task1 = new Task("Task1", "");
            //task1Instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            Instruction task1Instruction = new Instruction(task1.name, interfaces);
            task1Instruction.SetContent("Title", "Stage 1");
            task1Instruction.SetContent("Narration", "This is the first crossroad. Please follow to the direction with the tomato picture.");
            task1Instruction.SetContent("Description", "This is the first crossroad. Please follow to the direction with the tomato picture.");
            task1.AddInstruction(task1Instruction);
            task1.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp2), 7.0f), RelationalOperator.SmallerOrEqual);
            //task1.exit = new Condition(new TaskState(task1, TaskProgressState.Started), Condition.Operator.Equal, new TimeState(0, 0, 1));
            scenario.Add(task1);

            Task task2 = new Task("Task2", "");
            //task1Instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            Instruction task2Instruction = new Instruction(task2.name, interfaces);
            task2Instruction.SetContent("Title", "Stage 2");
            task2Instruction.SetContent("Narration", "This is the second crossroad. Please follow to the direction with the blue bird picture.");
            task2Instruction.SetContent("Description", "This is the second crossroad. Please follow to the direction with the blue bird picture.");
            task2.AddInstruction(task2Instruction);
            task2.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp3), 7.0f), RelationalOperator.SmallerOrEqual);
            scenario.Add(task2);

            Task task3 = new Task("Task3", "");
            //task1Instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            Instruction task3Instruction = new Instruction(task3.name, interfaces);
            task3Instruction.SetContent("Title", "Stage 3");
            task3Instruction.SetContent("Narration", "This is the third crossroad. Please follow to the direction with the yellow car picture.");
            task3Instruction.SetContent("Description", "This is the third crossroad. Please follow to the direction with the yellow car picture.");
            task3.AddInstruction(task3Instruction);
            task3.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp4), 7.0f), RelationalOperator.SmallerOrEqual);
            scenario.Add(task3);

            Task task4 = new Task("Task4", "");
            //task1Instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            Instruction task4Instruction = new Instruction(task4.name, interfaces);
            task4Instruction.SetContent("Title", "Stage 4");
            task4Instruction.SetContent("Narration", "This is the fourth crossroad. Please follow to the direction with the bitcoin picture.");
            task4Instruction.SetContent("Description", "This is the fourth crossroad. Please follow to the direction with the bitcoin picture.");
            task4.AddInstruction(task4Instruction);
            task4.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(cp5), 7.0f), RelationalOperator.SmallerOrEqual);
            scenario.Add(task4);

            Task task5 = new Task("Task5", "");
            //task1Instruction = new Instruction("첫 번째 단계로 조이스틱을 조종하여 X 좌표를 43으로 Y 좌표를 -29로 맞춰주세요.");
            Instruction task5Instruction = new Instruction(task5.name, interfaces);
            task5Instruction.SetContent("Title", "Stage 5");
            task5Instruction.SetContent("Narration", "This is the fifth crossroad. Please follow to the direction with the grayscale cup picture.");
            task5Instruction.SetContent("Description", "This is the fifth crossroad. Please follow to the direction with the grayscale cup picture.");
            task5.AddInstruction(task5Instruction);
            task5.exit = new Condition(new DistanceState(new MoveState(actor), new MoveState(goal), 7.0f), RelationalOperator.SmallerOrEqual);
            scenario.Add(task5);

            Task ending = new Task("Finish", "");
            Instruction endingInstruction = new Instruction(ending.name, interfaces);
            endingInstruction.SetContent("Title", "Finish");
            endingInstruction.SetContent("Narration", "Well done! Your training is successfully terminated.");
            endingInstruction.SetContent("Description", "Well done! Your training is successfully terminated.");
            ending.AddInstruction(endingInstruction);
            ending.exit = new Condition(new InputUpState(actor, (int)KeyCode.C), RelationalOperator.Equal);
            scenario.Add(ending);

            scenario.MakeProcedure();

            scenario.Activate();
        }

        // Update is called once per frame
        void Update()
        {
            if (scenario != null)
                scenario.Proceed();
        }
    }
}

