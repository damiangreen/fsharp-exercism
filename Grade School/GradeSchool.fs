module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty

let grade (grade: int) (school: School) =
    match school.TryGetValue grade with
    | true, value -> value |> List.sort
    | _ -> []

let add (student: string) (gradeV: int) (school: School) : School =
    school.Add(gradeV, grade gradeV school @ [ student ]) // inefficent?

let roster (school: School) : string list =
    let students =
        school
        |> Map.toSeq
        |> (Seq.map (fun (_, v) -> List.sort v))
        |> List.concat

    students
