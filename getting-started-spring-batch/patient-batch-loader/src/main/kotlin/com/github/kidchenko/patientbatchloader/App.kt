package com.github.kidchenko.patientbatchloader

import org.springframework.batch.core.configuration.annotation.EnableBatchProcessing
import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
@EnableBatchProcessing
class App

fun main(args: Array<String>) {
	runApplication<App>(*args)
}
