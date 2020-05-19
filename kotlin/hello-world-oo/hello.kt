class Greeter(val name: String) {

    fun greet() {
        println("Hello $name")
    }
}

fun main() {
    val g = Greeter("Juca")
    g.greet()
}
