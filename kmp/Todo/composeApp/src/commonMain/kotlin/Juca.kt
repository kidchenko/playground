import androidx.compose.animation.AnimatedVisibility
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.material.Button
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Text
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import kotlinx.coroutines.delay
import org.jetbrains.compose.resources.painterResource
import org.jetbrains.compose.ui.tooling.preview.Preview

import todo.composeapp.generated.resources.Res
import todo.composeapp.generated.resources.compose_multiplatform

@Composable
@Preview
fun Juca(timeout: () -> Unit) {

    LaunchedEffect(Unit) {
        delay(2000) // Delay for 2 seconds in milliseconds
        timeout() // Call the timeout function to signal content display
    }


    MaterialTheme {

        Box(
            modifier = Modifier
                .fillMaxSize()
                .background(
                    color = Color.Red
            )
        )
    }

}