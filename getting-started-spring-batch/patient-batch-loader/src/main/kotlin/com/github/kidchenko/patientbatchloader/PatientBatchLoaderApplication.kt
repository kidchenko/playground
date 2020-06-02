package com.github.kidchenko.patientbatchloader

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class PatientBatchLoaderApplication

fun main(args: Array<String>) {
	runApplication<PatientBatchLoaderApplication>(*args)
}
