Describe "Basic" {
    Context "Arithmetic" {
        It "1 + 1 shoukd be 2" {
            1 + 1 | Should -Be 2
        }
    }

    Context "String" {
        It "An i letter should not be in team - like" {
            "team" | Should -Not -BeLike "*i*"
        }

        It "An i letter should not be in team - match" {
            "team" | Should -Not -Match "i"
        }
    }

    Context "AAA Aproach" {
        $stringToTest = "team"

        It "An i letter should not be in team - like" {
            $stringToTest | Should -Not -BeLike "*i*"
        }

        It "An e letter should be in team - like" {
            $stringToTest | Should -BeLike "*e*"
        }

        It "An i letter should not be in team - match" {
            $stringToTest | Should -Not -Match "i"
        }
    }
}
