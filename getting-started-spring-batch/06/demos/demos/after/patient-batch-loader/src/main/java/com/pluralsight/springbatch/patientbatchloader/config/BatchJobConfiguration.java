package com.pluralsight.springbatch.patientbatchloader.config;

import com.pluralsight.springbatch.patientbatchloader.domain.PatientEntity;
import com.pluralsight.springbatch.patientbatchloader.domain.PatientRecord;
import org.apache.commons.lang3.StringUtils;
import org.springframework.batch.core.*;
import org.springframework.batch.core.configuration.JobRegistry;
import org.springframework.batch.core.configuration.annotation.JobBuilderFactory;
import org.springframework.batch.core.configuration.annotation.StepBuilderFactory;
import org.springframework.batch.core.configuration.annotation.StepScope;
import org.springframework.batch.core.configuration.support.JobRegistryBeanPostProcessor;
import org.springframework.batch.item.ItemReader;
import org.springframework.batch.item.ItemWriter;
import org.springframework.batch.item.file.FlatFileItemReader;
import org.springframework.batch.item.file.LineMapper;
import org.springframework.batch.item.file.builder.FlatFileItemReaderBuilder;
import org.springframework.batch.item.file.mapping.DefaultLineMapper;
import org.springframework.batch.item.file.transform.DelimitedLineTokenizer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.io.PathResource;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.function.Function;

@Configuration
public class BatchJobConfiguration {

    @Autowired
    private JobBuilderFactory jobBuilderFactory;

    @Autowired
    private StepBuilderFactory stepBuilderFactory;

    @Autowired
    private ApplicationProperties applicationProperties;

    @Bean
    JobRegistryBeanPostProcessor jobRegistryBeanPostProcessor(JobRegistry jobRegistry) {
        JobRegistryBeanPostProcessor postProcessor = new JobRegistryBeanPostProcessor();
        postProcessor.setJobRegistry(jobRegistry);
        return postProcessor;
    }

    @Bean
    public Job job(Step step) throws Exception {
        return this.jobBuilderFactory
            .get(Constants.JOB_NAME)
            .validator(validator())
            .start(step)
            .build();
    }

    @Bean
    public Step step(ItemReader<PatientRecord> itemReader,
                     Function<PatientRecord, PatientEntity> processor) throws Exception {
        return this.stepBuilderFactory
            .get(Constants.STEP_NAME)
            .<PatientRecord, PatientEntity>chunk(2)
            .reader(itemReader)
            .processor(processor)
            .writer(writer())
            .build();
    }

    @Bean
    public JobParametersValidator validator() {
        return new JobParametersValidator() {
            @Override
            public void validate(JobParameters parameters) throws JobParametersInvalidException {
                String fileName = parameters.getString(Constants.JOB_PARAM_FILE_NAME);
                if (StringUtils.isBlank(fileName)) {
                    throw new JobParametersInvalidException(
                        "The patient-batch-loader.fileName parameter is required.");
                }
                try {
                    Path file = Paths.get(applicationProperties.getBatch().getInputPath() +
                        File.separator + fileName);
                    if (Files.notExists(file) || !Files.isReadable(file)) {
                        throw new Exception("File did not exist or was not readable");
                    }
                } catch (Exception e) {
                    throw new JobParametersInvalidException(
                        "The input path + patient-batch-loader.fileName parameter needs to " +
                            "be a valid file location.");
                }
            }
        };
    }

    @Bean
    @StepScope
    public FlatFileItemReader<PatientRecord> reader(
        @Value("#{jobParameters['" + Constants.JOB_PARAM_FILE_NAME + "']}")String fileName) {
        return new FlatFileItemReaderBuilder<PatientRecord>()
            .name(Constants.ITEM_READER_NAME)
            .resource(
                new PathResource(
                    Paths.get(applicationProperties.getBatch().getInputPath() +
                        File.separator + fileName)))
            .linesToSkip(1)
            .lineMapper(lineMapper())
            .build();
    }

    @Bean
    public LineMapper<PatientRecord> lineMapper() {
        DefaultLineMapper<PatientRecord> mapper = new DefaultLineMapper<>();
        mapper.setFieldSetMapper((fieldSet) -> new PatientRecord(
            fieldSet.readString(0), fieldSet.readString(1),
            fieldSet.readString(2), fieldSet.readString(3),
            fieldSet.readString(4), fieldSet.readString(5),
            fieldSet.readString(6), fieldSet.readString(7),
            fieldSet.readString(8), fieldSet.readString(9),
            fieldSet.readString(10), fieldSet.readString(11),
            fieldSet.readString(12)));
        mapper.setLineTokenizer(new DelimitedLineTokenizer());
        return mapper;
    }

    @Bean
    @StepScope
    public Function<PatientRecord, PatientEntity> processor() {
        return (patientRecord) ->  {
            return new PatientEntity(
                patientRecord.getSourceId(),
                patientRecord.getFirstName(),
                patientRecord.getMiddleInitial(),
                patientRecord.getLastName(),
                patientRecord.getEmailAddress(),
                patientRecord.getPhoneNumber(),
                patientRecord.getStreet(),
                patientRecord.getCity(),
                patientRecord.getState(),
                patientRecord.getZip(),
                LocalDate.parse(patientRecord.getBirthDate(), DateTimeFormatter.ofPattern("M/dd/yyyy")),
                patientRecord.getSsn());
        };
    }

    @Bean
    @StepScope
    public ItemWriter<PatientEntity> writer() {
        return new ItemWriter<PatientEntity>() {
            @Override
            public void write(List<? extends PatientEntity> items) throws Exception {
                for (PatientEntity patientEntity : items) {
                    System.err.println("Writing item: " + patientEntity.toString());
                }
            }
        };
    }
}
