﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RemindMe.Data;
using System;

namespace RemindMe.Migrations
{
    [DbContext(typeof(RemindMeDbContext))]
    [Migration("20180515134426_Added Cell Phone Number to User Table")]
    partial class AddedCellPhoneNumbertoUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RemindMe.Models.NonRecurringEvents", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NonRecuringEventCreateDate");

                    b.Property<string>("NonRecurringEventDescription");

                    b.Property<string>("NonRecurringEventName");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("NonRecurringEvents");
                });

            modelBuilder.Entity("RemindMe.Models.NonRecurringReminders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NonRecuringReminderAlertFrequency");

                    b.Property<string>("NonRecuringReminderCreateDate");

                    b.Property<string>("NonRecurringReminderDescription");

                    b.Property<string>("NonRecurringReminderFirstAlertTime");

                    b.Property<string>("NonRecurringReminderLastAlertDate");

                    b.Property<string>("NonRecurringReminderName");

                    b.Property<string>("NonRecurringReminderSecondAlertTime");

                    b.Property<string>("NonRecurringReminderStartAlertDate");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("NonRecurringReminders");
                });

            modelBuilder.Entity("RemindMe.Models.RecurringEvents", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RecuringEventCreateDate");

                    b.Property<string>("RecurringEventDescription");

                    b.Property<string>("RecurringEventName");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("RecurringEvents");
                });

            modelBuilder.Entity("RemindMe.Models.RecurringReminders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RecuringReminderAlertFrequency");

                    b.Property<string>("RecuringReminderCreateDate");

                    b.Property<string>("RecurringReminderDescription");

                    b.Property<string>("RecurringReminderFirstAlertTime");

                    b.Property<string>("RecurringReminderLastAlertDate");

                    b.Property<string>("RecurringReminderName");

                    b.Property<string>("RecurringReminderRepeatFrequency");

                    b.Property<string>("RecurringReminderSecondAlertTime");

                    b.Property<string>("RecurringReminderStartAlertDate");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("RecurringReminders");
                });

            modelBuilder.Entity("RemindMe.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhoneNumber");

                    b.Property<string>("Email");

                    b.Property<string>("GCalEmail");

                    b.Property<string>("GCalEmailPassword");

                    b.Property<string>("Password");

                    b.Property<string>("UserCreateDate");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RemindMe.Models.NonRecurringEvents", b =>
                {
                    b.HasOne("RemindMe.Models.User", "User")
                        .WithMany("NonRecurringEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RemindMe.Models.NonRecurringReminders", b =>
                {
                    b.HasOne("RemindMe.Models.User", "User")
                        .WithMany("NonRecurringReminders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RemindMe.Models.RecurringEvents", b =>
                {
                    b.HasOne("RemindMe.Models.User", "User")
                        .WithMany("RecurringEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RemindMe.Models.RecurringReminders", b =>
                {
                    b.HasOne("RemindMe.Models.User", "User")
                        .WithMany("RecurringReminders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
