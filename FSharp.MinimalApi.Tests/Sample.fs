module Tests

open Expecto

[<Tests>]
let tests =
  testList
    "samples"
    [ testCase "foo"
      <| fun _ ->
        let subject = true
        Expect.isTrue subject "I compute, therefore I am."

      testCase "I'm skipped (should skip)"
      <| fun _ -> Tests.skiptest "Yup, waiting for a sunny day..."

      testCase "contains things"
      <| fun _ -> Expect.containsAll [| 2; 3; 4 |] [| 2; 4 |] "This is the case; {2,3,4} contains {2,4}"

      ]