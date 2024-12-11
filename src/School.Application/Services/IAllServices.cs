using School.Application.Models;
using School.Application.Models.AllModels;
using School.Application.Models.ModelsByS.Attendance;
using School.Application.Models.ModelsByS.Category;
using School.Application.Models.ModelsByS.Certificate;
using School.Application.Models.ModelsByS.Course;
using School.Application.Models.ModelsByS.Employee;
using School.Application.Models.ModelsByS.Enrollment;
using School.Application.Models.ModelsByS.Event;
using School.Application.Models.ModelsByS.Exam;
using School.Application.Models.ModelsByS.Feedback;
using School.Application.Models.ModelsByS.Group;
using School.Application.Models.ModelsByS.Lesson;
using School.Application.Models.ModelsByS.LessonSchedule;
using School.Application.Models.ModelsByS.Payment;
using School.Application.Models.ModelsByS.Person;
using School.Application.Models.ModelsByS.Raiting;
using School.Application.Models.ModelsByS.Room;
using School.Application.Models.ModelsByS.Student;
using School.Application.Models.ModelsByS.Subject;
using School.Application.Models.ModelsByS.TeacherSub;
using School.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace School.Application.Services.ServicesByS
{
    public interface IStudentService
    {
        Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<StudentResponseModel>> GetAllAsync();
        Task<StudentResponseModel> GetByIdAsync(Guid id);
        Task<UpdateStudentResponseModel> UpdateAsync(Guid id,
            UpdateStudentModel updateStudentModel, CancellationToken cancellationToken = default);
    }

    public interface IEmployeeService
    {
        Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<EmployeeResponseModel>> GetAllAsync();
        Task<EmployeeResponseModel> GetByIdAsync(Guid id);
        Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id,
            UpdateEmployeeModel updateEmployeeModel, CancellationToken cancellationToken = default);
    }

    public interface IPersonServices
    {
        Task<CreatePersonResponseModel> CreateAsync(Models.ModelsByS.Category.CreatePersonModel createPersonModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<PersonResponseModel>> GetAllAsync();
        Task<PersonResponseModel> GetByIdAsync(Guid id);
        Task<UpdatePersonResponseModel> UpdateAsync(Guid id,
            UpdatePersonModel updatePersonModel, CancellationToken cancellationToken = default);
    }


    public interface IGroupService
    {
        Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<GroupResponseModel>> GetAllAsync();
        Task<GroupResponseModel> GetByIdAsync(Guid id);
        Task<UpdateGroupResponseModel> UpdateAsync(Guid id,
            UpdateGroupModel updateGroupModel, CancellationToken cancellationToken = default);
    }

    public interface IExamService
    {
        Task<CreateExamResponseModel> CreateAsync(CreateExamModel createExamModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ExamResponseModel>> GetAllAsync();
        Task<ExamResponseModel> GetByIdAsync(Guid id);
        Task<UpdateExamResponseModel> UpdateAsync(Guid id,
            UpdateExamModel updateExamModel, CancellationToken cancellationToken = default);
    }

    public interface ISubjectService
    {
        Task<CreateSubjectResponseModel> CreateAsync(CreateSubjectModel createSubjectModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<SubjectResponseModel>> GetAllAsync();
        Task<SubjectResponseModel> GetByIdAsync(Guid id);
        Task<UpdateSubjectResponseModel> UpdateAsync(Guid id,
            UpdateSubjectModel updateSubjectModel, CancellationToken cancellationToken = default);
    }

    public interface IRaitingService
    {
        Task<CreateRaitingResponseModel> CreateAsync(CreateRaitingModel createRaitingModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<RaitingResponseModel>> GetAllAsync();
        Task<RaitingResponseModel> GetByIdAsync(Guid id);
        Task<UpdateRaitingResponseModel> UpdateAsync(Guid id,
            UpdateRaitingModel updateRaitingModel, CancellationToken cancellationToken = default);
    }

    public interface IRoomServices
    {
        Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<RoomResponseModel>> GetAllAsync();
        Task<RoomResponseModel> GetByIdAsync(Guid id);
        Task<UpdateRoomResponseModel> UpdateAsync(Guid id,
            UpdateRoomModel updateRoomModel, CancellationToken cancellationToken = default);
    }

    public interface IEnrollmentService
    {
        Task<CreateEnrollmentResponseModel> CreateAsync(CreateEnrollmentModel createEnrollmentModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<EnrollmentResponseModel>> GetAllAsync();
        Task<EnrollmentResponseModel> GetByIdAsync(Guid id);
        Task<UpdateEnrollmentResponseModel> UpdateAsync(Guid id,
            UpdateEnrollmentModel updateEnrollmentModel, CancellationToken cancellationToken = default);
    }


    public interface IEventService
    {
        Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<EventResponseModel>> GetAllAsync();
        Task<EventResponseModel> GetByIdAsync(Guid id);
        Task<UpdateEventResponseModel> UpdateAsync(Guid id,
            UpdateEventModel updateEventModel, CancellationToken cancellationToken = default);
    }

    public interface IFeedbackService
    {
        Task<CreateFeedbackResponseModel> CreateAsync(CreateFeedbackModel createFeedbackModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<FeedbackResponseModel>> GetAllAsync();
        Task<FeedbackResponseModel> GetByIdAsync(Guid id);
        Task<UpdateFeedbackResponseModel> UpdateAsync(Guid id,
            UpdateFeedbackModel updateFeedbackModel, CancellationToken cancellationToken = default);
    }

    public interface IPaymentService
    {
        Task<CreatePaymentResponseModel> CreateAsync(CreatePaymentModel createPaymentModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<PaymentResponseModel>> GetAllAsync();
        Task<PaymentResponseModel> GetByIdAsync(Guid id);
        Task<UpdatePaymentResponseModel> UpdateAsync(Guid id,
            UpdatePaymentModel updatePaymentModel, CancellationToken cancellationToken = default);
    }

    public interface ILessonService
    {
        Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<LessonResponseModel>> GetAllAsync();
        Task<LessonResponseModel> GetByIdAsync(Guid id);
        Task<UpdateLessonResponseModel> UpdateAsync(Guid id,
            UpdateLessonModel updateLessonModel, CancellationToken cancellationToken = default);
    }

    public interface ILessonScheduleService
    {
        Task<CreateLessonScheduleResponseModel> CreateAsync(CreateLessonScheduleModel createLessonScheduleModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<LessonScheduleResponseModel>> GetAllAsync();
        Task<LessonScheduleResponseModel> GetByIdAsync(Guid id);
        Task<UpdateLessonScheduleResponseModel> UpdateAsync(Guid id,
            UpdateLessonScheduleModel updateLessonScheduleModel, CancellationToken cancellationToken = default);
    }

    public interface ITeacherSubService
    {
        Task<CreateTeacherSubResponseModel> CreateAsync(CreateTeacherSubModel createTeacherSubModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TeacherSubResponseModel>> GetAllAsync();
        Task<TeacherSubResponseModel> GetByIdAsync(Guid id);
        Task<UpdateTeacherSubResponseModel> UpdateAsync(Guid id,
            UpdateTeacherSubModel updateTeacherSubModel, CancellationToken cancellationToken = default);
    }

    public interface IAnnouncementService
    {
        Task<CreateAnnouncementResponseModel> CreateAsync(CreateAnnouncementModel createAnnouncementModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<AnnouncementResponseModel>> GetAllAsync();
        Task<AnnouncementResponseModel> GetByIdAsync(Guid id);
        Task<UpdateAnnouncementResponseModel> UpdateAsync(Guid id,
            UpdateAnnouncementModel updateAnnouncementModel, CancellationToken cancellationToken = default);
    }

    public interface IAttendanceService
    {
        Task<CreateAttendanceResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<AttendanceResponseModel>> GetAllAsync();
        Task<AttendanceResponseModel> GetByIdAsync(Guid id);
        Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id,
            UpdateAttendanceModel updateAttendanceModel, CancellationToken cancellationToken = default);
    }

    public interface ICertificateService
    {
        Task<CreateCertificateResponseModel> CreateAsync(CreateCertificateModel createCertificateModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CertificateResponseModel>> GetAllAsync();
        Task<CertificateResponseModel> GetByIdAsync(Guid id);
        Task<UpdateCertificateResponseModel> UpdateAsync(Guid id,
            UpdateCertificateModel updateCertificateModel, CancellationToken cancellationToken = default);
    }
    public interface ICourseService
    {
        Task<CreateCourseResponseModel> CreateAsync(CreateCourseModel createCourseModel,
            CancellationToken cancellationToken = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CourseResponseModel>> GetAllAsync();
        Task<CourseResponseModel> GetByIdAsync(Guid id);
        Task<UpdateCourseResponseModel> UpdateAsync(Guid id,
            UpdateCourseModel updateCourseModel, CancellationToken cancellationToken = default);
    }


}
