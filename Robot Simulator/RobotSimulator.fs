module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { direction: Direction
      position: Position }

let create (direction: Direction) (position: Position) : Robot =
    { direction = direction
      position = position }

let rotateRight currentPosition =
    match currentPosition with
    | North -> East
    | East -> South
    | South -> West
    | West -> North

let rotateLeft currentPosition =
    match currentPosition with
    | North -> West
    | East -> North
    | South -> East
    | West -> South

let advance (robot: Robot) : Position =
    match robot.direction with
    | North -> fst robot.position, (snd robot.position) + 1
    | East -> (fst robot.position) + 1, snd robot.position
    | West -> (fst robot.position) - 1, snd robot.position
    | South -> fst robot.position, (snd robot.position) - 1

let singleMove (robot: Robot) (move: char) =
    match move with
    | 'R' ->
        { robot with
              direction = rotateRight robot.direction }
    | 'L' ->
        { robot with
              direction = rotateLeft robot.direction }
    | 'A' -> { robot with position = advance robot }
    | _ -> robot

let rec executeMove (instructions: list<char>) (robot: Robot) =
    match instructions with
    | [] -> robot
    | head :: tail -> executeMove tail (singleMove robot head)

let move (instructions: string) (robot: Robot) : Robot =
    executeMove (instructions |> Seq.toList) robot
