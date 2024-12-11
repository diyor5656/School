using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using School.Application.Exceptions;
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
using School.Application.Services.ServicesByS;
using School.Core.Entities;
using School.DataAccess.Repositories;
using School.DataAccess.Repositories.Impl;

namespace School.Application.Services.Impl
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly IMemoryCache _memoryCache;

        public GroupService(IGroupRepository groupRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel, CancellationToken cancellationToken)
        {
            var group = _mapper.Map<Group>(createGroupModel);

            var createdGroup = await _groupRepository.AddAsync(group);

            return new CreateGroupResponseModel
            {
                Id = createdGroup.Id
            };
        }

        public async Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetFirstAsync(g => g.Id == id);
            if (group == null) throw new NotFoundException($"Group {id} not found");

            group.Name = updateGroupModel.Name;

            var updatedGroup = await _groupRepository.UpdateAsync(group);

            return new UpdateGroupResponseModel
            {
                Id = updatedGroup.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetFirstAsync(g => g.Id == id);
            if (group == null) throw new NotFoundException("Group not found");

            var deletedGroup = await _groupRepository.DeleteAsync(group);

            return new BaseResponseModel
            {
                Id = deletedGroup.Id
            };
        }

        public async Task<GroupResponseModel> GetByIdAsync(Guid id)
        {
            var group = await _groupRepository.GetFirstAsync(g => g.Id == id);
            if (group == null)
                throw new NotFoundException($"Group with id {id} not found");

            return _mapper.Map<GroupResponseModel>(group);
        }

        public async Task<IEnumerable<GroupResponseModel>> GetAllAsync()
        {
            var groups = await _groupRepository.GetAllAsync(g => true);
            return _mapper.Map<IEnumerable<GroupResponseModel>>(groups);
        }
    }

    public class RoomService : IRoomServices
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IMemoryCache _memoryCache;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<Room>(createRoomModel);

            var createdRoom = await _roomRepository.AddAsync(room);

            return new CreateRoomResponseModel
            {
                Id = createdRoom.Id
            };
        }

        public async Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetFirstAsync(r => r.Id == id);
            if (room == null) throw new NotFoundException($"Room {id} not found");

            room.Name = updateRoomModel.Name;
            room.Num = updateRoomModel.Num;

            var updatedRoom = await _roomRepository.UpdateAsync(room);

            return new UpdateRoomResponseModel
            {
                Id = updatedRoom.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetFirstAsync(r => r.Id == id);
            if (room == null) throw new NotFoundException("Room not found");

            var deletedRoom = await _roomRepository.DeleteAsync(room);

            return new BaseResponseModel
            {
                Id = deletedRoom.Id
            };
        }

        public async Task<RoomResponseModel> GetByIdAsync(Guid id)
        {
            var room = await _roomRepository.GetFirstAsync(r => r.Id == id);
            if (room == null)
                throw new NotFoundException($"Room with id {id} not found");

            return _mapper.Map<RoomResponseModel>(room);
        }

        public async Task<IEnumerable<RoomResponseModel>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync(r => true);
            return _mapper.Map<IEnumerable<RoomResponseModel>>(rooms);
        }
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMemoryCache _memoryCache;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(createEmployeeModel);

            var createdEmployee = await _employeeRepository.AddAsync(employee);

            return new CreateEmployeeResponseModel
            {
                Id = createdEmployee.Id
            };
        }

        public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);
            if (employee == null) throw new NotFoundException($"Employee {id} not found");

            //employee.EmployeeStatus = updateEmployeeModel.EmployeeStatus;

            var updatedEmployee = await _employeeRepository.UpdateAsync(employee);

            return new UpdateEmployeeResponseModel
            {
                Id = updatedEmployee.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);
            if (employee == null) throw new NotFoundException("Employee not found");

            var deletedEmployee = await _employeeRepository.DeleteAsync(employee);

            return new BaseResponseModel
            {
                Id = deletedEmployee.Id
            };
        }

        public async Task<EmployeeResponseModel> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);
            if (employee == null)
                throw new NotFoundException($"Employee with id {id} not found");

            return _mapper.Map<EmployeeResponseModel>(employee);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync(e => true);
            return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
        }
    }

    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IMemoryCache _memoryCache;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(createStudentModel);

            var createdStudent = await _studentRepository.AddAsync(student);

            return new CreateStudentResponseModel
            {
                Id = createdStudent.Id
            };
        }

        public async Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetFirstAsync(s => s.Id == id);
            if (student == null) throw new NotFoundException($"Student {id} not found");



            var updatedStudent = await _studentRepository.UpdateAsync(student);

            return new UpdateStudentResponseModel
            {
                Id = updatedStudent.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetFirstAsync(s => s.Id == id);
            if (student == null) throw new NotFoundException("Student not found");

            var deletedStudent = await _studentRepository.DeleteAsync(student);

            return new BaseResponseModel
            {
                Id = deletedStudent.Id
            };
        }

        public async Task<StudentResponseModel> GetByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetFirstAsync(s => s.Id == id);
            if (student == null)
                throw new NotFoundException($"Student with id {id} not found");

            return _mapper.Map<StudentResponseModel>(student);
        }

        public async Task<IEnumerable<StudentResponseModel>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync(s => true);
            return _mapper.Map<IEnumerable<StudentResponseModel>>(students);
        }
    }

    public class ExamService : IExamService
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly IMemoryCache _memoryCache;

        public ExamService(IExamRepository examRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateExamResponseModel> CreateAsync(CreateExamModel createExamModel, CancellationToken cancellationToken)
        {
            var exam = _mapper.Map<Exam>(createExamModel);

            var createdExam = await _examRepository.AddAsync(exam);

            return new CreateExamResponseModel
            {
                Id = createdExam.Id
            };
        }

        public async Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel, CancellationToken cancellationToken)
        {
            var exam = await _examRepository.GetFirstAsync(e => e.Id == id);
            if (exam == null) throw new NotFoundException($"Exam {id} not found");

            exam.RoomId = updateExamModel.RoomId;
            exam.StudentId = updateExamModel.StudentId;
            exam.SubjectId = updateExamModel.SubjectId;

            var updatedExam = await _examRepository.UpdateAsync(exam);

            return new UpdateExamResponseModel
            {
                Id = updatedExam.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var exam = await _examRepository.GetFirstAsync(e => e.Id == id);
            if (exam == null) throw new NotFoundException("Exam not found");

            var deletedExam = await _examRepository.DeleteAsync(exam);

            return new BaseResponseModel
            {
                Id = deletedExam.Id
            };
        }

        public async Task<ExamResponseModel> GetByIdAsync(Guid id)
        {
            var exam = await _examRepository.GetFirstAsync(e => e.Id == id);
            if (exam == null)
                throw new NotFoundException($"Exam with id {id} not found");

            return _mapper.Map<ExamResponseModel>(exam);
        }

        public async Task<IEnumerable<ExamResponseModel>> GetAllAsync()
        {
            var exams = await _examRepository.GetAllAsync(e => true);
            return _mapper.Map<IEnumerable<ExamResponseModel>>(exams);
        }
    }

    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMemoryCache _memoryCache;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateSubjectResponseModel> CreateAsync(CreateSubjectModel createSubjectModel, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(createSubjectModel);

            var createdSubject = await _subjectRepository.AddAsync(subject);

            return new CreateSubjectResponseModel
            {
                Id = createdSubject.Id
            };
        }

        public async Task<UpdateSubjectResponseModel> UpdateAsync(Guid id, UpdateSubjectModel updateSubjectModel, CancellationToken cancellationToken)
        {
            var subject = await _subjectRepository.GetFirstAsync(s => s.Id == id);
            if (subject == null) throw new NotFoundException($"Subject {id} not found");

            subject.Name = updateSubjectModel.Name;

            var updatedSubject = await _subjectRepository.UpdateAsync(subject);

            return new UpdateSubjectResponseModel
            {
                Id = updatedSubject.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var subject = await _subjectRepository.GetFirstAsync(s => s.Id == id);
            if (subject == null) throw new NotFoundException("Subject not found");

            var deletedSubject = await _subjectRepository.DeleteAsync(subject);

            return new BaseResponseModel
            {
                Id = deletedSubject.Id
            };
        }

        public async Task<SubjectResponseModel> GetByIdAsync(Guid id)
        {
            var subject = await _subjectRepository.GetFirstAsync(s => s.Id == id);
            if (subject == null)
                throw new NotFoundException($"Subject with id {id} not found");

            return _mapper.Map<SubjectResponseModel>(subject);
        }

        public async Task<IEnumerable<SubjectResponseModel>> GetAllAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync(s => true);
            return _mapper.Map<IEnumerable<SubjectResponseModel>>(subjects);
        }
    }

    public class RaitingService : IRaitingService
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _raitingRepository;
        private readonly IMemoryCache _memoryCache;

        public RaitingService(IRatingRepository raitingRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _raitingRepository = raitingRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateRaitingResponseModel> CreateAsync(CreateRaitingModel createRaitingModel, CancellationToken cancellationToken)
        {
            var raiting = _mapper.Map<Rating>(createRaitingModel);

            var createdRaiting = await _raitingRepository.AddAsync(raiting);

            return new CreateRaitingResponseModel
            {
                Id = createdRaiting.Id
            };
        }

        public async Task<UpdateRaitingResponseModel> UpdateAsync(Guid id, UpdateRaitingModel updateRaitingModel, CancellationToken cancellationToken)
        {
            var raiting = await _raitingRepository.GetFirstAsync(r => r.Id == id);
            if (raiting == null) throw new NotFoundException($"Raiting {id} not found");

            raiting.Score = updateRaitingModel.Score;

            var updatedRaiting = await _raitingRepository.UpdateAsync(raiting);

            return new UpdateRaitingResponseModel
            {
                Id = updatedRaiting.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var raiting = await _raitingRepository.GetFirstAsync(r => r.Id == id);
            if (raiting == null) throw new NotFoundException("Raiting not found");

            var deletedRaiting = await _raitingRepository.DeleteAsync(raiting);

            return new BaseResponseModel
            {
                Id = deletedRaiting.Id
            };
        }

        public async Task<RaitingResponseModel> GetByIdAsync(Guid id)
        {
            var raiting = await _raitingRepository.GetFirstAsync(r => r.Id == id);
            if (raiting == null)
                throw new NotFoundException($"Raiting with id {id} not found");

            return _mapper.Map<RaitingResponseModel>(raiting);
        }

        public async Task<IEnumerable<RaitingResponseModel>> GetAllAsync()
        {
            var ratings = await _raitingRepository.GetAllAsync(r => true);
            return _mapper.Map<IEnumerable<RaitingResponseModel>>(ratings);
        }
    }


    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _announcementRepository;
        private readonly IMemoryCache _memoryCache;

        public AnnouncementService(IAttendanceRepository announcementRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateAnnouncementResponseModel> CreateAsync(CreateAnnouncementModel createAnnouncementModel, CancellationToken cancellationToken)
        {
            var announcement = _mapper.Map<Announcement>(createAnnouncementModel);
            var createdAnnouncement = await _announcementRepository.AddAsync(announcement);

            return new CreateAnnouncementResponseModel
            {
                Id = createdAnnouncement.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetFirstAsync(a => a.Id == id);
            if (announcement == null) throw new NotFoundException("Announcement not found");

            var deletedAnnouncement = await _announcementRepository.DeleteAsync(announcement);
            return new BaseResponseModel { Id = deletedAnnouncement.Id };
        }

        public async Task<AnnouncementResponseModel> GetByIdAsync(Guid id)
        {
            var announcement = await _announcementRepository.GetFirstAsync(a => a.Id == id);
            if (announcement == null) throw new NotFoundException($"Announcement with id {id} not found");

            return _mapper.Map<AnnouncementResponseModel>(announcement);
        }

        public async Task<IEnumerable<AnnouncementResponseModel>> GetAllAsync()
        {
            var announcements = await _announcementRepository.GetAllAsync(a => true);
            return _mapper.Map<List<AnnouncementResponseModel>>(announcements);
        }
    }

    public class AttendanceService : IAttendanceService
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMemoryCache _memoryCache;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateAttendanceResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel, CancellationToken cancellationToken)
        {
            var attendance = _mapper.Map<Attendance>(createAttendanceModel);
            var createdAttendance = await _attendanceRepository.AddAsync(attendance);

            return new CreateAttendanceResponseModel
            {
                Id = createdAttendance.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var attendance = await _attendanceRepository.GetFirstAsync(a => a.Id == id);
            if (attendance == null) throw new NotFoundException("Attendance not found");

            var deletedAttendance = await _attendanceRepository.DeleteAsync(attendance);
            return new BaseResponseModel { Id = deletedAttendance.Id };
        }

        public async Task<AttendanceResponseModel> GetByIdAsync(Guid id)
        {
            var attendance = await _attendanceRepository.GetFirstAsync(a => a.Id == id);
            if (attendance == null) throw new NotFoundException($"Attendance with id {id} not found");

            return _mapper.Map<AttendanceResponseModel>(attendance);
        }

        public async Task<IEnumerable<AttendanceResponseModel>> GetAllAsync()
        {
            var attendances = await _attendanceRepository.GetAllAsync(a => true);
            return _mapper.Map<List<AttendanceResponseModel>>(attendances);
        }
    }

    public class CertificateService : ICertificateService
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMemoryCache _memoryCache;

        public CertificateService(ICertificateRepository certificateRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateCertificateResponseModel> CreateAsync(CreateCertificateModel createCertificateModel, CancellationToken cancellationToken)
        {
            var certificate = _mapper.Map<Certificate>(createCertificateModel);
            var createdCertificate = await _certificateRepository.AddAsync(certificate);

            return new CreateCertificateResponseModel
            {
                Id = createdCertificate.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var certificate = await _certificateRepository.GetFirstAsync(c => c.Id == id);
            if (certificate == null) throw new NotFoundException("Certificate not found");

            var deletedCertificate = await _certificateRepository.DeleteAsync(certificate);
            return new BaseResponseModel { Id = deletedCertificate.Id };
        }

        public async Task<CertificateResponseModel> GetByIdAsync(Guid id)
        {
            var certificate = await _certificateRepository.GetFirstAsync(c => c.Id == id);
            if (certificate == null) throw new NotFoundException($"Certificate with id {id} not found");

            return _mapper.Map<CertificateResponseModel>(certificate);
        }

        public async Task<IEnumerable<CertificateResponseModel>> GetAllAsync()
        {
            var certificates = await _certificateRepository.GetAllAsync(c => true);
            return _mapper.Map<List<CertificateResponseModel>>(certificates);
        }
    }

    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IMemoryCache _memoryCache;

        public CourseService(ICourseRepository courseRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateCourseResponseModel> CreateAsync(CreateCourseModel createCourseModel, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(createCourseModel);
            var createdCourse = await _courseRepository.AddAsync(course);

            return new CreateCourseResponseModel
            {
                Id = createdCourse.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetFirstAsync(c => c.Id == id);
            if (course == null) throw new NotFoundException("Course not found");

            var deletedCourse = await _courseRepository.DeleteAsync(course);
            return new BaseResponseModel { Id = deletedCourse.Id };
        }

        public async Task<CourseResponseModel> GetByIdAsync(Guid id)
        {
            var course = await _courseRepository.GetFirstAsync(c => c.Id == id);
            if (course == null) throw new NotFoundException($"Course with id {id} not found");

            return _mapper.Map<CourseResponseModel>(course);
        }

        public async Task<IEnumerable<CourseResponseModel>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync(c => true);
            return _mapper.Map<List<CourseResponseModel>>(courses);
        }
    }

    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMemoryCache _memoryCache;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateEnrollmentResponseModel> CreateAsync(CreateEnrollmentModel createEnrollmentModel, CancellationToken cancellationToken)
        {
            var enrollment = _mapper.Map<Enrollment>(createEnrollmentModel);
            var createdEnrollment = await _enrollmentRepository.AddAsync(enrollment);

            return new CreateEnrollmentResponseModel
            {
                Id = createdEnrollment.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentRepository.GetFirstAsync(e => e.Id == id);
            if (enrollment == null) throw new NotFoundException("Enrollment not found");

            var deletedEnrollment = await _enrollmentRepository.DeleteAsync(enrollment);
            return new BaseResponseModel { Id = deletedEnrollment.Id };
        }

        public async Task<EnrollmentResponseModel> GetByIdAsync(Guid id)
        {
            var enrollment = await _enrollmentRepository.GetFirstAsync(e => e.Id == id);
            if (enrollment == null) throw new NotFoundException($"Enrollment with id {id} not found");

            return _mapper.Map<EnrollmentResponseModel>(enrollment);
        }

        public async Task<IEnumerable<EnrollmentResponseModel>> GetAllAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync(e => true);
            return _mapper.Map<List<EnrollmentResponseModel>>(enrollments);
        }
    }


    public class EventService : IAllService
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IMemoryCache _memoryCache;

        public EventService(IEventRepository eventRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel, CancellationToken cancellationToken)
        {
            var eventObj = _mapper.Map<Event>(createEventModel);
            var createdEvent = await _eventRepository.AddAsync(eventObj);

            return new CreateEventResponseModel
            {
                Id = createdEvent.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var eventObj = await _eventRepository.GetFirstAsync(e => e.Id == id);
            if (eventObj == null) throw new NotFoundException("Event not found");

            var deletedEvent = await _eventRepository.DeleteAsync(eventObj);
            return new BaseResponseModel { Id = deletedEvent.Id };
        }

        public async Task<EventResponseModel> GetByIdAsync(Guid id)
        {
            var eventObj = await _eventRepository.GetFirstAsync(e => e.Id == id);
            if (eventObj == null) throw new NotFoundException($"Event with id {id} not found");

            return _mapper.Map<EventResponseModel>(eventObj);
        }

        public async Task<IEnumerable<EventResponseModel>> GetAllAsync()
        {
            var events = await _eventRepository.GetAllAsync(e => true);
            return _mapper.Map<List<EventResponseModel>>(events);
        }
    }

    public class FeedbackService : IAllService
    {
        private readonly IMapper _mapper;
        private readonly IFeedBackRepository _feedbackRepository;
        private readonly IMemoryCache _memoryCache;

        public FeedbackService(IFeedBackRepository feedbackRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateFeedbackResponseModel> CreateAsync(CreateFeedbackModel createFeedbackModel, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Feedback>(createFeedbackModel);
            var createdFeedback = await _feedbackRepository.AddAsync(feedback);

            return new CreateFeedbackResponseModel
            {
                Id = createdFeedback.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetFirstAsync(f => f.Id == id);
            if (feedback == null) throw new NotFoundException("Feedback not found");

            var deletedFeedback = await _feedbackRepository.DeleteAsync(feedback);
            return new BaseResponseModel { Id = deletedFeedback.Id };
        }

        public async Task<FeedbackResponseModel> GetByIdAsync(Guid id)
        {
            var feedback = await _feedbackRepository.GetFirstAsync(f => f.Id == id);
            if (feedback == null) throw new NotFoundException($"Feedback with id {id} not found");

            return _mapper.Map<FeedbackResponseModel>(feedback);
        }

        public async Task<IEnumerable<FeedbackResponseModel>> GetAllAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync(f => true);
            return _mapper.Map<List<FeedbackResponseModel>>(feedbacks);
        }
    }

    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPyamentRepository _paymentRepository;
        private readonly IMemoryCache _memoryCache;

        public PaymentService(IPyamentRepository paymentRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreatePaymentResponseModel> CreateAsync(CreatePaymentModel createPaymentModel, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Payment>(createPaymentModel);
            var createdPayment = await _paymentRepository.AddAsync(payment);

            return new CreatePaymentResponseModel
            {
                Id = createdPayment.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetFirstAsync(p => p.Id == id);
            if (payment == null) throw new NotFoundException("Payment not found");

            var deletedPayment = await _paymentRepository.DeleteAsync(payment);
            return new BaseResponseModel { Id = deletedPayment.Id };
        }

        public async Task<PaymentResponseModel> GetByIdAsync(Guid id)
        {
            var payment = await _paymentRepository.GetFirstAsync(p => p.Id == id);
            if (payment == null) throw new NotFoundException($"Payment with id {id} not found");

            return _mapper.Map<PaymentResponseModel>(payment);
        }

        public async Task<IEnumerable<PaymentResponseModel>> GetAllAsync()
        {
            var payments = await _paymentRepository.GetAllAsync(p => true);
            return _mapper.Map<List<PaymentResponseModel>>(payments);
        }
    }

    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly IMemoryCache _memoryCache;

        public LessonService(ILessonRepository lessonRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel, CancellationToken cancellationToken)
        {
            var lesson = _mapper.Map<Lesson>(createLessonModel);
            var createdLesson = await _lessonRepository.AddAsync(lesson);

            return new CreateLessonResponseModel
            {
                Id = createdLesson.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetFirstAsync(l => l.Id == id);
            if (lesson == null) throw new NotFoundException("Lesson not found");

            var deletedLesson = await _lessonRepository.DeleteAsync(lesson);
            return new BaseResponseModel { Id = deletedLesson.Id };
        }

        public async Task<LessonResponseModel> GetByIdAsync(Guid id)
        {
            var lesson = await _lessonRepository.GetFirstAsync(l => l.Id == id);
            if (lesson == null) throw new NotFoundException($"Lesson with id {id} not found");

            return _mapper.Map<LessonResponseModel>(lesson);
        }

        public async Task<IEnumerable<LessonResponseModel>> GetAllAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync(l => true);
            return _mapper.Map<List<LessonResponseModel>>(lessons);
        }
    }

    public class LessonScheduleService : ILessonScheduleService
    {
        private readonly IMapper _mapper;
        private readonly ILessonScheduleRepository _lessonScheduleRepository;
        private readonly IMemoryCache _memoryCache;

        public LessonScheduleService(ILessonScheduleRepository lessonScheduleRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _lessonScheduleRepository = lessonScheduleRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateLessonScheduleResponseModel> CreateAsync(CreateLessonScheduleModel createLessonScheduleModel, CancellationToken cancellationToken)
        {
            var lessonSchedule = _mapper.Map<LessonSchedule>(createLessonScheduleModel);
            var createdLessonSchedule = await _lessonScheduleRepository.AddAsync(lessonSchedule);

            return new CreateLessonScheduleResponseModel
            {
                Id = createdLessonSchedule.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var lessonSchedule = await _lessonScheduleRepository.GetFirstAsync(l => l.Id == id);
            if (lessonSchedule == null) throw new NotFoundException("LessonSchedule not found");

            var deletedLessonSchedule = await _lessonScheduleRepository.DeleteAsync(lessonSchedule);
            return new BaseResponseModel { Id = deletedLessonSchedule.Id };
        }

        public async Task<LessonScheduleResponseModel> GetByIdAsync(Guid id)
        {
            var lessonSchedule = await _lessonScheduleRepository.GetFirstAsync(l => l.Id == id);
            if (lessonSchedule == null) throw new NotFoundException($"LessonSchedule with id {id} not found");

            return _mapper.Map<LessonScheduleResponseModel>(lessonSchedule);
        }

        public async Task<IEnumerable<LessonScheduleResponseModel>> GetAllAsync()
        {
            var lessonSchedules = await _lessonScheduleRepository.GetAllAsync(l => true);
            return _mapper.Map<List<LessonScheduleResponseModel>>(lessonSchedules);
        }
    }

    public class TeacherSubService : ITeacherSubService
    {
        private readonly IMapper _mapper;
        private readonly ITeachSubRepository _teacherSubRepository;
        private readonly IMemoryCache _memoryCache;

        public TeacherSubService(ITeachSubRepository teacherSubRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _teacherSubRepository = teacherSubRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateTeacherSubResponseModel> CreateAsync(CreateTeacherSubModel createTeacherSubModel, CancellationToken cancellationToken)
        {
            var teacherSub = _mapper.Map<TeachSub>(createTeacherSubModel);
            var createdTeacherSub = await _teacherSubRepository.AddAsync(teacherSub);

            return new CreateTeacherSubResponseModel
            {
                Id = createdTeacherSub.Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var teacherSub = await _teacherSubRepository.GetFirstAsync(t => t.Id == id);
            if (teacherSub == null) throw new NotFoundException("TeacherSub not found");

            var deletedTeacherSub = await _teacherSubRepository.DeleteAsync(teacherSub);
            return new BaseResponseModel { Id = deletedTeacherSub.Id };
        }

        public async Task<TeacherSubResponseModel> GetByIdAsync(Guid id)
        {
            var teacherSub = await _teacherSubRepository.GetFirstAsync(t => t.Id == id);
            if (teacherSub == null) throw new NotFoundException($"TeacherSub with id {id} not found");

            return _mapper.Map<TeacherSubResponseModel>(teacherSub);
        }

        public async Task<IEnumerable<TeacherSubResponseModel>> GetAllAsync()
        {
            var teacherSubs = await _teacherSubRepository.GetAllAsync(t => true);
            return _mapper.Map<List<TeacherSubResponseModel>>(teacherSubs);
        }
    }

    //public class PersonService : IPersonServices
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IUserRepository _personRepository;
    //    private readonly IMemoryCache _memoryCache;

    //    public PersonService(IUserRepository personRepository, IMapper mapper, IMemoryCache memoryCache)
    //    {
    //        _personRepository = personRepository;
    //        _mapper = mapper;
    //        _memoryCache = memoryCache;
    //    }

    //public async Task<CreatePersonResponseModel> CreateAsync(CreatePersonModel createPersonModel, CancellationToken cancellationToken)
    //{
    //    var person = _mapper.Map<User>(createPersonModel);

    //    var createdPerson = await _personRepository.AddAsync(person);

    //    return new CreatePersonResponseModel
    //    {
    //        Id = createdPerson.Id
    //    };
    //}

    //public async Task<UpdatePersonResponseModel> UpdateAsync(Guid id, UpdatePersonModel updatePersonModel, CancellationToken cancellationToken)
    //{
    //    var person = await _personRepository.GetFirstAsync(p => p.Id == id);
    //    if (person == null) throw new NotFoundException($"Person {id} not found");

    //    person.Name = updatePersonModel.Name;
    //    person.Email = updatePersonModel.Email;
    //    person.PhoneNumber = updatePersonModel.PhoneNumber;
    //    person.Gender = updatePersonModel.Gender;
    //    person.Age = updatePersonModel.Age;

    //    var updatedPerson = await _personRepository.UpdateAsync(person);

    //    return new UpdatePersonResponseModel
    //    {
    //        Id = updatedPerson.Id
    //    };
    //}

    //public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
    //{
    //    var person = await _personRepository.GetFirstAsync(p => p.Id == id);
    //    if (person == null) throw new NotFoundException("Person not found");

    //    var deletedPerson = await _personRepository.DeleteAsync(person);

    //    return new BaseResponseModel
    //    {
    //        Id = deletedPerson.Id
    //    };
    //}

    //public async Task<PersonResponseModel> GetByIdAsync(Guid id)
    //{
    //    var person = await _personRepository.GetFirstAsync(p => p.Id == id);
    //    if (person == null)
    //        throw new NotFoundException($"Person with id {id} not found");

    //    return _mapper.Map<PersonResponseModel>(person);
    //}

    //public async Task<IEnumerable<PersonResponseModel>> GetAllAsync()
    //{
    //    var people = await _personRepository.GetAllAsync(p => true);
    //    return _mapper.Map<IEnumerable<PersonResponseModel>>(people);
    //}
    //}

}
